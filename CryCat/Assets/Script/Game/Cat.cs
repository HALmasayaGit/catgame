using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // �L���
    enum CatStatus
    {
        LIVE,
        Heaven,
    }
    // �����L��Ԃ͐���
    CatStatus catSts = CatStatus.LIVE;

    [SerializeField, Header("�L�ړ����x")]
    private float CatSpeed = 0.1f;

    // �ړ��t���O
    private bool MoveFlg = false;

    // �������W
    private Vector3 InitPos;

    // �I�u�W�F�N�g�i�[�p
    GameObject Player;
    private GameObject canvas;

    [SerializeField, Header("�l���|�C���g")]
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
                    Move();     // �ړ�����
                }
                break;
            case CatStatus.Heaven:
                // �X�v���C�g�؂�ւ�
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
            catSts = CatStatus.Heaven;           // ��Ԃ��w�u����
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
            catSts = CatStatus.Heaven;           // ��Ԃ��w�u����
            Player.GetComponent<Player>().AddHeavenChain();
            Player.GetComponent<Player>().AddHeavenPoint(GetPoint);
            Invoke("DestroyThis", 2.5f);
            canvas.GetComponent<GetPointController>().Attack(this.transform.position);
            Destroy(collision.gameObject);
        }
    }

    private void Move()         // �ړ��֐�
    {
        Vector3 newPos = this.gameObject.transform.position + GetMoveDirection() * CatSpeed;

        this.transform.position = newPos;
    }

    private void HeavenMove()
    {
        Vector3 newPos = new Vector3(Mathf.Sin(Time.time)*0.5f+InitPos.x,0.05f+this.transform.position.y,this.transform.position.z);

        this.transform.position = newPos;
    }

    Vector3 GetMoveDirection()  // �v���C���[�̋�������Ƃ͋t�̃x�N�g�����擾����
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
