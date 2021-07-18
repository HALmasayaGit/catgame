using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�ړ����x")]
    private float PlayerSpeed = 0.1f;

    // ���є͈̓I�u�W�F�N�g
    GameObject ShoutArea;

    // ���ԓ��̓t���O
    private bool CryFlg = false;

    [SerializeField, Header("���ׂ�Ԋu")]
    private float CryInterval = 1.0f;
    private float CryTemptime = 0.0f;

    // �|�C���g�̏���
    private int HeavenPoint = 0;
    private int HeavenPointChain = 0;         // �w�u���A��
    private int HeavenPointGet = 0;           // UI�\�L�p

    public static int HeavenPointResult = 0;        // ���ʃ|�C���g�i�[�p

    // �����\����
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

    // �����t���O
    DirectionFlg directionFlg = new DirectionFlg(false, false, false, false);
    DirectionFlg directionFlgTemp = new DirectionFlg(false, false, false, false);

    // Start is called before the first frame update
    void Start()
    {
        ShoutArea = (GameObject)Resources.Load("ShoutArea");
        HeavenPointResult = 0;      // static�ϐ��̏�����
    }

    void Update()
    {
        if(TimeCounter.countzero_flg)PlayerInput();  // �v���C���[����
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();           // �v���C���[�ړ�

        // ���уG�t�F�N�g�֘A�̏���
        if (CryFlg)
        {
            if (CryTemptime == 0)
            {
                HeavenPointChain = 0;   // �w�u���A��������
                InstantCryEffect();     // ���уG�t�F�N�g����
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
        // �ړ��֘A�̓���
        if (Input.GetKey("d")) { directionFlg.right = true; }
        else { directionFlg.right = false; }

        if (Input.GetKey("a")) { directionFlg.left = true; }
        else { directionFlg.left = false; }

        if (Input.GetKey("w")) { directionFlg.back = true; }
        else { directionFlg.back = false; }

        if (Input.GetKey("s")) { directionFlg.front = true; }
        else { directionFlg.front = false; }

        // ���Ԋ֘A�̓���
        if (Input.GetMouseButtonDown(0))    // ���N���b�N
        {
            CryFlg = true;
        }
    }

    // �ړ�����
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

    // ���уG�t�F�N�g�𐶐�
    void InstantCryEffect()
    {
        // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
        GameObject instance = (GameObject)Instantiate(ShoutArea,
                                                      new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                                                      Quaternion.identity);// ��]���Ȃ�
        instance.name = "ShoutArea";
        instance.transform.parent = this.gameObject.transform;
    }

    public void SetCryFlg(bool _flg)
    {
        CryFlg = _flg;
    }

    // �w�u���|�C���g
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
