using System.Collections;
using UnityEngine;

public class RenderBoard : MonoBehaviour {
	public GameObject testBitcoin;

	Grid grid;
	int x = -3;
	int dir = 1;
	float time;
	
	void Awake() {
		grid = GetComponent<Grid>();
	}

	void Start() {
		time = Time.time;
	}


	void Update() {
		if (Time.time - time > 0.5f) {
			x += dir;
			dir = (x == 3) ? -1 : (x == -3) ? 1 : dir;

			testBitcoin.transform.localPosition =
				grid.GetCellCenterLocal(new Vector3Int(x, 0, 0));
			
			time = Time.time;
		}
	}
}