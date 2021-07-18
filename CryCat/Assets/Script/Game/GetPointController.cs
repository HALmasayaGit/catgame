using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPointController : MonoBehaviour
{
    private GameObject PointText; //ダメージテキストを格納

    private GameObject canvas;//親にするキャンバスを格納

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //親にするキャンバスを取得
        canvas = GameObject.Find("MainCanvas");
        PointText = (GameObject)Resources.Load("PointText");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void Attack(Vector3 _pos)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;

        GameObject text;
        // テキストをプレハブから生成
        text = Instantiate(PointText, new Vector3(0, 0, 0), Quaternion.identity);
        // テキストの親をキャンバスにセット
        text.transform.SetParent(canvas.transform, false);
        // テキストの座標をセット
        text.transform.position = new Vector3(tmp.x, tmp.y, 0.0f);
        Debug.Log(tmp);
        // テキストの内容
        text.GetComponent<Text>().text = Player.GetComponent<Player>().GetHeavenPointGet()+ "Ｐ";
    }
}
