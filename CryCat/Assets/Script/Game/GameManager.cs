using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // オブジェクト生成用の変数
    //==猫
    GameObject ObjCat;
    [SerializeField, Header("猫が出るインターバル")] public float CatInterval = 5.0f;
    private float CatRandomX;       // 猫の出現X座標
    private float CatRandomY;       // 猫の出現Y座標
    private float CatTmptime = 0;   // 猫の時間保管用

    //==ポイント
    GameObject ObjPoint;
    [SerializeField, Header("マタタビが出るインターバル")] public float PointInterval = 3.0f;
    private float PointRandomX;       // マタタビの出現X座標
    private float PointRandomY;       // マタタビの出現Y座標
    private float PointTmptime = 0;   // マタタビの時間保管用

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクト参照
        ObjCat = (GameObject)Resources.Load("Cat");
        ObjPoint = (GameObject)Resources.Load("Point");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //==オブジェクト生成==============================
        //==猫
        // 時間経過
        CatTmptime += Time.deltaTime;
        // インターバル毎に猫を出現させる
        if (CatTmptime >= CatInterval)
        {
            // 猫の座標を指定範囲内でランダムに決める
            CatRandomX = Random.Range(-7.0f, 7.0f);
            CatRandomY = Random.Range(-3.0f, 3.0f);

            // 猫生成
            InstantObject(ObjCat, CatRandomX, CatRandomY);

            // 時間初期化
            CatTmptime = 0;
        }

        //==マタタビ
        // 時間経過
        PointTmptime += Time.deltaTime;
        // インターバル毎に猫を出現させる
        if (PointTmptime >= PointInterval)
        {
            // 猫の座標を指定範囲内でランダムに決める
            PointRandomX = Random.Range(-7.0f, 7.0f);
            PointRandomY = Random.Range(-3.0f, 3.0f);

            // 猫生成
            InstantObject(ObjPoint, PointRandomX, PointRandomY);

            // 時間初期化
            PointTmptime = 0;
        }
    }

    // プレハブを元にオブジェクト生成する関数
    void InstantObject(GameObject _obj,float _x,float _y)
    {
        GameObject instance = (GameObject)Instantiate(_obj,
                                                        new Vector3(_x, _y, 0.0f),
                                                        Quaternion.identity);
    }
}
