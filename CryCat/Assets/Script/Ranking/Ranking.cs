using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField, Header("数値")]
    int point;

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位", "ランキング6位", "ランキング7位", "ランキング8位", "ランキング9位" };
    int[] rankingValue = new int[9];

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[9];

    [SerializeField, Header("あなた　がでるテキスト")]
    public Text text;
    // あなたが被らないようフラグ
    private bool you_flg = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        GetRanking();

        // Ranking用にスコアを取得
        point = Player.HeavenPointResult;

        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            if (point == rankingValue[i] && !you_flg)
            {
                text.text = " YOU";
                rankingText[i].text = rankingValue[i].ToString() + "ヘブン" + text.text;
                rankingText[i].color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                you_flg = true;
            }
            else
            {
                rankingText[i].text = rankingValue[i].ToString() + "ヘブン";
            }

        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}
