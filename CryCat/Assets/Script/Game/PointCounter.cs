using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    // ポイントを表示するText型
    public Text pointText;
    // プレイヤーの入れ物
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pointText.text = Player.GetComponent<Player>().GetHeavenPoint().ToString() + "ヘブン";
    }
}
