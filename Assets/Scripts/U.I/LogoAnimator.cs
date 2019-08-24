using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimator : MonoBehaviour
{
  public Animator anim;
  void Update( ) {
      if(Input.GetKeyDown(KeyCode.Space)){
          anim.SetBool("PlayCinematic", true);
      }
  }
}
