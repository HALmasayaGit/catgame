using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField, Header("���l")]
    int point;

    string[] ranking = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��", "�����L���O6��", "�����L���O7��", "�����L���O8��", "�����L���O9��" };
    int[] rankingValue = new int[9];

    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[9];

    [SerializeField, Header("���Ȃ��@���ł�e�L�X�g")]
    public Text text;
    // ���Ȃ������Ȃ��悤�t���O
    private bool you_flg = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        GetRanking();

        // Ranking�p�ɃX�R�A���擾
        point = Player.HeavenPointResult;

        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            if (point == rankingValue[i] && !you_flg)
            {
                text.text = " YOU";
                rankingText[i].text = rankingValue[i].ToString() + "�w�u��" + text.text;
                rankingText[i].color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                you_flg = true;
            }
            else
            {
                rankingText[i].text = rankingValue[i].ToString() + "�w�u��";
            }

        }
    }

    /// <summary>
    /// �����L���O�Ăяo��
    /// </summary>
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(int _value)
    {
        //�������ݗp
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }

        //����ւ����l��ۑ�
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}
