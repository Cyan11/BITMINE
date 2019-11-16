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
      Color.blue, Color.magenta, Color.red, Color.yellow
   };
   void Awake() {UpdateSheetColor();}

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
      
       var pos = player.data.position;
       CallDirection(player, direction.GetDirection());
      if (player.data.position == Vector2Int.zero) {
         if(player.data.heldBitcoins < 3)
         {
            ++player.data.heldBitcoins;

         } 
        
           player.data.position = pos;
      }
 
      if(player.data.position == player.data.startPosition){
         player.data.baseBitcoins += player.data.heldBitcoins;
         player.data.heldBitcoins = 0;
      }
      
      yield return new  WaitForSeconds(moveDelay);
   }

   void NextPlayer() {
    currentPlayer = (currentPlayer + 1) % 4;
    UpdateSheetColor();
   }

   void CallDirection(Player player, DirButton.Direction dir) {
      var pos = player.data.position;
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
             if (player.data.position == Vector2Int.zero) {
         if(player.data.heldBitcoins < 3)
         {
            ++player.data.heldBitcoins;

         }   player.data.position = pos;
      }
      }
      
              
   }
  void UpdateSheetColor() {
     sheetGraphic.color = SheetColors[currentPlayer];
  }
}


 