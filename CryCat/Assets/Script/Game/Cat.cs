using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // 猫状態
    enum CatStatus
    {
        LIVE,
        Heaven,
    }
    // 初期猫状態は生存
    CatStatus catSts = CatStatus.LIVE;

    [SerializeField, Header("猫移動速度")]
    private float CatSpeed = 0.1f;

    // 移動フラグ
    private bool MoveFlg = false;

    // 初期座標
    private Vector3 InitPos;

    // オブジェクト格納用
    GameObject Player;
    private GameObject canvas;

    [SerializeField, Header("獲得ポイント")]
    private int GetPoint = 300;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        canvas = GameObject.Find("MainCanvas");
        InitPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (catSts)
        {
            case CatStatus.LIVE:
                if (MoveFlg)
                {
                    Move();     // 移動処理
                }
                break;
            case CatStatus.Heaven:
                // スプライト切り替え
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(true);
                HeavenMove();
                break;
        }

    }

    // collsion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point" && catSts == CatStatus.LIVE && this.MoveFlg)
        {
            catSts = CatStatus.Heaven;           // 状態をヘブンに
            Player.GetComponent<Player>().AddHeavenChain();
            Player.GetComponent<Player>().AddHeavenPoint(GetPoint);
            Invoke("DestroyThis", 2.5f);
            canvas.GetComponent<GetPointController>().Attack(this.transform.position);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Wall" && catSts == CatStatus.LIVE)
        {
            DestroyThis();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Point" && catSts == CatStatus.LIVE && this.MoveFlg)
        {
            catSts = CatStatus.Heaven;           // 状態をヘブンに
            Player.GetComponent<Player>().AddHeavenChain();
            Player.GetComponent<Player>().AddHeavenPoint(GetPoint);
            Invoke("DestroyThis", 2.5f);
            canvas.GetComponent<GetPointController>().Attack(this.transform.position);
            Destroy(collision.gameObject);
        }
    }

    private void Move()         // 移動関数
    {
        Vector3 newPos = this.gameObject.transform.position + GetMoveDirection() * CatSpeed;

        this.transform.position = newPos;
    }

    private void HeavenMove()
    {
        Vector3 newPos = new Vector3(Mathf.Sin(Time.time)*0.5f+InitPos.x,0.05f+this.transform.position.y,this.transform.position.z);

        this.transform.position = newPos;
    }

    Vector3 GetMoveDirection()  // プレイヤーの居る方向とは逆のベクトルを取得する
    {
        Vector3 v = (Player.transform.position - this.transform.position).normalized;
        return -v;
    }


    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    // Setter
    public void SetMoveFlg(bool _flg)
    {
        this.MoveFlg = _flg;
    }
}
