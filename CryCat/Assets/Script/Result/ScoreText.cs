using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // ŠÔ‚ğ•\¦‚·‚éTextŒ^‚Ì•Ï”
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = Player.HeavenPointResult + "ƒwƒuƒ“";
    }
}
