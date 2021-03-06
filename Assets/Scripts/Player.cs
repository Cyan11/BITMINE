﻿using System;
using UnityEngine;

public class Player : MonoBehaviour{
 public PlayerData data;
 public Grid grid;
 new Renderer renderer;
 public bool GameMode;

 void Awake() {
      data.position = data.startPosition;
           data.baseBitcoins = 0;
           data.heldBitcoins = 0;
      renderer = GetComponentInChildren<MeshRenderer>();
     
 }
 void Start() {
     renderer.material.color = GetColorFromType(data.cellType);
     }
void FixedUpdate() {
    var newPos = grid.GetCellCenterLocal((Vector3Int)data.position);
    transform.localPosition = Vector3.Lerp( transform.localPosition, newPos, 0.1f);

}
public void Up() 
   => data.position.y = Mathf.Clamp(data.position.y - 1, -3, 3);

public void Down() 
   => data.position.y = Mathf.Clamp(data.position.y + 1, -3, 3);

public void Left() 
   => data.position.x = Mathf.Clamp(data.position.x - 1, -3, 3);

public void Right() 
   => data.position.x = Mathf.Clamp(data.position.x + 1, -3, 3);


    public static Color GetColorFromType(Board.Cell cellType) {
        switch(cellType) {
            case Board.Cell.PlayerBlue:
               return Color.blue;
            case Board.Cell.PlayerRed:
               return Color.red;
            case Board.Cell.PlayerPurple:
               return Color.magenta;
            case Board.Cell.PlayerYellow:
                return Color.yellow;
            default : throw new Exception("Colors not available ");
        }
    }
    
}
