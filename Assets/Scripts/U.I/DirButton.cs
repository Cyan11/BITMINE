using UnityEngine;
using UnityEngine.UI;

public class DirButton : MonoBehaviour
{  public enum Direction {
  Up = 3, Right = 2, Down = 1, Left = 0, None = 4
}
  static readonly float[] DirectionAngles = new float[]{
      180, 270, 0, 90
  };
  Graphic graphic;
  void Awake() {
    graphic = GetComponent<Graphic>();
  }
  public Direction direction = Direction.Up;

  void Start() {
      ApplyDirection();
  }
  public void OnClick() {
     int dir = (int)direction;
     dir = (dir + 1) % 5;
     direction = (Direction)dir;
     ApplyDirection();
  }
  void ApplyDirection() {
  if (direction == Direction.None) {
    graphic.color = new Color(1f, 1f, 1f, 0.25f);
  }
  else{
    var rot = transform.localRotation.eulerAngles;
    rot.z = DirectionAngles[(int)direction];
    transform.localRotation = Quaternion.Euler(rot);
     graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, 1f);
  }}
  
  public Direction GetDirection() => direction;
  public void SetDirection(Direction dir) {
      direction = dir;
      ApplyDirection();
  }
  
}