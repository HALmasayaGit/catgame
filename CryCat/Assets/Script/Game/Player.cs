using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Header("プレイヤー移動速度")]
    private float PlayerSpeed = 0.1f;

    // 叫び範囲オブジェクト
    GameObject ShoutArea;

    // 叫ぶ入力フラグ
    private bool CryFlg = false;

    [SerializeField, Header("叫べる間隔")]
    private float CryInterval = 1.0f;
    private float CryTemptime = 0.0f;

    // ポイントの処理
    private int HeavenPoint = 0;
    private int HeavenPointChain = 0;         // ヘブン連鎖
    private int HeavenPointGet = 0;           // UI表記用

    public static int HeavenPointResult = 0;        // 結果ポイント格納用

    // 方向構造体
    public struct DirectionFlg
    {
        public bool right;
        public bool left;
        public bool back;
        public bool front;
        public DirectionFlg(bool _right, bool _left, bool _back, bool _front)
        {
            this.right = _right;
            this.left = _left;
            this.back = _back;
            this.front = _front;
        }
    }

    // 方向フラグ
    DirectionFlg directionFlg = new DirectionFlg(false, false, false, false);
    DirectionFlg directionFlgTemp = new DirectionFlg(false, false, false, false);

    // Start is called before the first frame update
    void Start()
    {
        ShoutArea = (GameObject)Resources.Load("ShoutArea");
        HeavenPointResult = 0;      // static変数の初期化
    }

    void Update()
    {
        if(TimeCounter.countzero_flg)PlayerInput();  // プレイヤー入力
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();           // プレイヤー移動

        // 叫びエフェクト関連の処理
        if (CryFlg)
        {
            if (CryTemptime == 0)
            {
                HeavenPointChain = 0;   // ヘブン連鎖初期化
                InstantCryEffect();     // 叫びエフェクト生成
            }
            CryTemptime += Time.deltaTime;
        }
        else
        {
            CryTemptime = 0;
        }

        HeavenPointResult = GetHeavenPoint();
    }

    void PlayerInput()
    {
        // 移動関連の入力
        if (Input.GetKey("d")) { directionFlg.right = true; }
        else { directionFlg.right = false; }

        if (Input.GetKey("a")) { directionFlg.left = true; }
        else { directionFlg.left = false; }

        if (Input.GetKey("w")) { directionFlg.back = true; }
        else { directionFlg.back = false; }

        if (Input.GetKey("s")) { directionFlg.front = true; }
        else { directionFlg.front = false; }

        // 叫ぶ関連の入力
        if (Input.GetMouseButtonDown(0))    // 左クリック
        {
            CryFlg = true;
        }
    }

    // 移動処理
    void PlayerMove()
    {
        if (directionFlg.right)
        {
            if (this.transform.position.x < 8) this.transform.Translate(PlayerSpeed, 0.0f, 0.0f);
        }

        if (directionFlg.left)
        {
            if (this.transform.position.x > -8) this.transform.Translate(-PlayerSpeed, 0.0f, 0.0f);
        }

        if (directionFlg.back)
        {
            if (this.transform.position.y < 4) this.transform.Translate(0.0f, PlayerSpeed, 0.0f);
        }

        if (directionFlg.front)
        {
            if (this.transform.position.y > -4) this.transform.Translate(0.0f, -PlayerSpeed, 0.0f);
        }
    }

    // 叫びエフェクトを生成
    void InstantCryEffect()
    {
        // プレハブを元にオブジェクトを生成する
        GameObject instance = (GameObject)Instantiate(ShoutArea,
                                                      new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                                                      Quaternion.identity);// 回転しない
        instance.name = "ShoutArea";
        instance.transform.parent = this.gameObject.transform;
    }

    public void SetCryFlg(bool _flg)
    {
        CryFlg = _flg;
    }

    // ヘブンポイント
    public void AddHeavenPoint(int _pt)
    {
        this.HeavenPoint += _pt * HeavenPointChain;
        this.HeavenPointGet = _pt * HeavenPointChain;
    }

    public void AddHeavenChain()
    {
        this.HeavenPointChain += 1;
    }

    public int GetHeavenPoint() { return this.HeavenPoint; }

    // Getter
    public int GetHeavenPointGet()
    {
        return HeavenPointGet;
    }
}
