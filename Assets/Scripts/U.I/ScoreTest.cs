using UnityEngine;
using UnityEngine.UI;

public class ScoreTest : MonoBehaviour
{
    public PlayerData playerData;
    public Text heldScore, baseScore;
    void FixedUpdate(){
        baseScore.text = "  " + playerData.baseBitcoins.ToString();
        heldScore.text = "  " + playerData.heldBitcoins.ToString();
        
    }
}
