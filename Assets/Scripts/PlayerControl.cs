using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	public DirButton direction1, direction2, direction3;
	public List<Player> players;
	public static int currentPlayer = 0;
	public Graphic sheetGraphic;
	public float moveDelay = 0.5f;
	public GameObject executeButton;
	public AudioClip gotBitcoinSound;
	public Board board;

	AudioSource audioSource;

	public Color[] sheetColors = {
		Color.blue, Color.magenta, Color.red, Color.yellow
	};

	void Awake() {
		UpdateSheetColor();
		audioSource = this.GetComponent<AudioSource>();
	}

	void Start() {
		foreach (var p in players) {
			p.data.heldBitcoins = 0;
			p.data.baseBitcoins = 0;
		}
	}

	public void Execute() =>
		StartCoroutine(SlowExecute());

	IEnumerator SlowExecute() {
		executeButton.SetActive(false);

		var player = players[currentPlayer];

		yield return PlayerAction(player, direction1);
		yield return PlayerAction(player, direction2);
		yield return PlayerAction(player, direction3);
		
		NextPlayer();
		executeButton.SetActive(true);
	}

	IEnumerator PlayerAction(Player player, DirButton direction) {
		var lastPos = player.data.position;
		
		CallDirection(player, direction.GetDirection());
		
		Debug.Log($"pos = {player.data.position}");
		var cell = board.GetCell(player.data.position);

		if (player.data.position == Vector2Int.zero) {
			if (player.data.heldBitcoins < 3) {
				++player.data.heldBitcoins;
				audioSource.PlayOneShot(gotBitcoinSound);
			}
			
			player.data.position = lastPos;
		} else if (player.data.position == player.data.startPosition) {
			player.data.baseBitcoins += player.data.heldBitcoins;
			player.data.heldBitcoins = 0;
			player.data.position = lastPos;
		} else if ((cell & Board.Cell.AnyPlayer) != 0) {
			var other = GetPlayerAtCell(cell);
			
			Steal(player, other);

			player.data.position = lastPos;
		}

		yield return new WaitForSeconds(moveDelay);
	}

	void NextPlayer() {
		currentPlayer = (currentPlayer + 1) % 4;
		UpdateSheetColor();
	}

	void CallDirection(Player player, DirButton.Direction dir) {
		switch (dir) {
			case DirButton.Direction.Up:
				player.Up();
				break;
			case DirButton.Direction.Down:
				player.Down();
				break;
			case DirButton.Direction.Left:
				player.Left();
				break;
			case DirButton.Direction.Right:
				player.Right();
				break;
		}
	}

	void UpdateSheetColor()
		=> sheetGraphic.color = sheetColors[currentPlayer];
	
	Player GetPlayerAtCell(Board.Cell cell) {
		switch (cell) {
			case Board.Cell.PlayerRed:
				return players[0];
			case Board.Cell.PlayerPurple:
				return players[1];
			case Board.Cell.PlayerBlue:
				return players[2];
			case Board.Cell.PlayerYellow:
				return players[3];
			default:
				throw new Exception(
					"A célula do inimigo não tem um inimigo?"
				);
		}
	}
	
	void Steal(Player player, Player other) {
		if (player.data.heldBitcoins < 3 && other.data.heldBitcoins > 0) {
			--other.data.heldBitcoins;
			++player.data.heldBitcoins;
		}
	}
}






