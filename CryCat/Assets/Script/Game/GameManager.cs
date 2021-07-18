using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �I�u�W�F�N�g�����p�̕ϐ�
    //==�L
    GameObject ObjCat;
    [SerializeField, Header("�L���o��C���^�[�o��")] public float CatInterval = 5.0f;
    private float CatRandomX;       // �L�̏o��X���W
    private float CatRandomY;       // �L�̏o��Y���W
    private float CatTmptime = 0;   // �L�̎��ԕۊǗp

    //==�|�C���g
    GameObject ObjPoint;
    [SerializeField, Header("�}�^�^�r���o��C���^�[�o��")] public float PointInterval = 3.0f;
    private float PointRandomX;       // �}�^�^�r�̏o��X���W
    private float PointRandomY;       // �}�^�^�r�̏o��Y���W
    private float PointTmptime = 0;   // �}�^�^�r�̎��ԕۊǗp

    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g�Q��
        ObjCat = (GameObject)Resources.Load("Cat");
        ObjPoint = (GameObject)Resources.Load("Point");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //==�I�u�W�F�N�g����==============================
        //==�L
        // ���Ԍo��
        CatTmptime += Time.deltaTime;
        // �C���^�[�o�����ɔL���o��������
        if (CatTmptime >= CatInterval)
        {
            // �L�̍��W���w��͈͓��Ń����_���Ɍ��߂�
            CatRandomX = Random.Range(-7.0f, 7.0f);
            CatRandomY = Random.Range(-3.0f, 3.0f);

            // �L����
            InstantObject(ObjCat, CatRandomX, CatRandomY);

            // ���ԏ�����
            CatTmptime = 0;
        }

        //==�}�^�^�r
        // ���Ԍo��
        PointTmptime += Time.deltaTime;
        // �C���^�[�o�����ɔL���o��������
        if (PointTmptime >= PointInterval)
        {
            // �L�̍��W���w��͈͓��Ń����_���Ɍ��߂�
            PointRandomX = Random.Range(-7.0f, 7.0f);
            PointRandomY = Random.Range(-3.0f, 3.0f);

            // �L����
            InstantObject(ObjPoint, PointRandomX, PointRandomY);

            // ���ԏ�����
            PointTmptime = 0;
        }
    }

    // �v���n�u�����ɃI�u�W�F�N�g��������֐�
    void InstantObject(GameObject _obj,float _x,float _y)
    {
        GameObject instance = (GameObject)Instantiate(_obj,
                                                        new Vector3(_x, _y, 0.0f),
                                                        Quaternion.identity);
    }
}
