﻿using UnityEngine; 
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
   public DirButton direction1, direction2, direction3;
   public List<Player> players;
   public Graphic sheetGraphic;
   public static int currentPlayer = 0;
   
   public Color[] SheetColors = {
      Color.blue, Color.red, Color.magenta, Color.yellow
   };
   void Awake() {UpdateSheetColor();}

   public void Execute() {
    var player = players[currentPlayer];
    CallDirection(player, direction1.GetDirection());
    CallDirection(player, direction2.GetDirection());
    CallDirection(player, direction3.GetDirection());
    
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