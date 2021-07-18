using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    // �^�C�����~�b�g
    [SerializeField] public float timeLimit = 60.0f;
    public static bool countzero_flg = false;
    public static bool stop_flg = false;

    public float countup = 0.0f;

    // ���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    // �J�E���g�_�E����\������e�L�X�g�^�̕ϐ�
    public Text CountText;
    public static float countdown = 4f;
    int count;

    // �����L���O�J�ڃt���O
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
        {// �J�E���g�_�E��3�b
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
        {// �Q�[���X�^�[�g�\��
            CountText.text = "START!";
            countdown -= Time.deltaTime;
            this.transform.GetChild(2).GetComponent<TimeUI>().Setroop(true);
        }
        if (countdown < 0)
        {
            countzero_flg = true;

            //���Ԃ�\������
            timeText.text = timeLimit.ToString("f0");
            CountText.text = "";

            if (timeLimit <= 0)
            {// �������Ԗ����Ȃ����烊�U���g�֔��
                timeLimit = 0;
                if (!ToRankingTransitionFlg)
                {
                    FadeManager.Instance.LoadScene("Result", 2.0f);
                    ToRankingTransitionFlg = true;
                }
            }
            else if (timeLimit > 0)
            {
                // �Q�[���������ԃJ�E���g�_�E��
                countup += Time.deltaTime;

                //���Ԃ��J�E���g����
                timeLimit -= Time.deltaTime;

            }
        }
    }
}
