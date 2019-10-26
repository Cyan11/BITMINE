using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
   public DirButton direction1, direction2, direction3;
   public List<Player> players;
   public Graphic sheetGraphic;
   public static int currentPlayer = 0;
   public float moveDelay = 0.5f;
   public GameObject executeButton;
   
   public Color[] SheetColors = {
      Color.blue, Color.red, Color.magenta, Color.yellow
   };
   void Awake() {UpdateSheetColor();
   
   }

   public void Execute() {
      StartCoroutine(SlowExecute());
   }


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
      CallDirection(player, direction.GetDirection());
      if(
         player.data.position == Vector2Int.zero &&
         player.data.heldBitcoins < 3
      ){
         ++player.data.heldBitcoins;
      }
      if(player.data.position == player.data.startPosition){
         player.data.heldBitcoins =+ player.data.baseBitcoins;
         player.data.heldBitcoins = 0;
      }
      yield return new  WaitForSeconds(moveDelay);
   }

   void NextPlayer() {
    currentPlayer = (currentPlayer + 1) % 4;
    UpdateSheetColor();
   }

   void CallDirection(Player player, DirButton.Direction dir) {
      switch(dir) {
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
  void UpdateSheetColor() {
     sheetGraphic.color = SheetColors[currentPlayer];
  }
}


 