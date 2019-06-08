using UnityEngine;

public class DirButton : MonoBehaviour
{  public enum Direction {
    Up = 0, Right = 1, Down = 2, Left = 3
}
  static readonly float[] DirectionAngles = new float[]{
      180, 270, 0, 90
  };
  
  public Direction direction = Direction.Up;
  void Start() {
      ApplyDirection();
  }
  public void OnClick() {
     int dir = (int)direction;
     dir = (dir + 1) % 4;
     direction = (Direction)dir;
     ApplyDirection();
  }
  void ApplyDirection() {
    var rot = transform.localRotation.eulerAngles;
    rot.z = DirectionAngles[(int)direction];
    transform.localRotation = Quaternion.Euler(rot);
  }
  /* 
  public Direction getDirection() => direction;
  public void SetDirection(Direction dir) {
      direction = dir;
      ApplyDirection();
  }
  */
}