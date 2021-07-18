using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    // タイムリミット
    [SerializeField] public float timeLimit = 60.0f;
    public static bool countzero_flg = false;
    public static bool stop_flg = false;

    public float countup = 0.0f;

    // 時間を表示するText型の変数
    public Text timeText;

    // カウントダウンを表示するテキスト型の変数
    public Text CountText;
    public static float countdown = 4f;
    int count;

    // ランキング遷移フラグ
    bool ToRankingTransitionFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        countzero_flg = false;
        stop_flg = false;
        countdown = 4f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countdown > 1)
        {// カウントダウン3秒
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();

            if (3 < countdown && countdown <= 3.9)
            {
                
            }
            if (2 < countdown && countdown <= 3)
            {
               
            }
            if (1 < countdown && countdown <= 2)
            {
                
            }
        }
        if (countdown <= 1 && countdown >= 0)
        {// ゲームスタート表示
            CountText.text = "START!";
            countdown -= Time.deltaTime;
            this.transform.GetChild(2).GetComponent<TimeUI>().Setroop(true);
        }
        if (countdown < 0)
        {
            countzero_flg = true;

            //時間を表示する
            timeText.text = timeLimit.ToString("f0");
            CountText.text = "";

            if (timeLimit <= 0)
            {// 制限時間無くなったらリザルトへ飛ぶ
                timeLimit = 0;
                if (!ToRankingTransitionFlg)
                {
                    FadeManager.Instance.LoadScene("Result", 2.0f);
                    ToRankingTransitionFlg = true;
                }
            }
            else if (timeLimit > 0)
            {
                // ゲーム制限時間カウントダウン
                countup += Time.deltaTime;

                //時間をカウントする
                timeLimit -= Time.deltaTime;

            }
        }
    }
}
