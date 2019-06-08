using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName="Data/PlayerData")]
public class PlayerData : ScriptableObject
{
   public Board.Cell cellType;
   public Vector2Int position;
   public int heldBitcoins, baseBitcoins;
   public string playerName;
   //Player functions later
}