using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPointController : MonoBehaviour
{
    private GameObject PointText; //�_���[�W�e�L�X�g���i�[

    private GameObject canvas;//�e�ɂ���L�����o�X���i�[

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //�e�ɂ���L�����o�X���擾
        canvas = GameObject.Find("MainCanvas");
        PointText = (GameObject)Resources.Load("PointText");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void Attack(Vector3 _pos)
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;

        GameObject text;
        // �e�L�X�g���v���n�u���琶��
        text = Instantiate(PointText, new Vector3(0, 0, 0), Quaternion.identity);
        // �e�L�X�g�̐e���L�����o�X�ɃZ�b�g
        text.transform.SetParent(canvas.transform, false);
        // �e�L�X�g�̍��W���Z�b�g
        text.transform.position = new Vector3(tmp.x, tmp.y, 0.0f);
        Debug.Log(tmp);
        // �e�L�X�g�̓��e
        text.GetComponent<Text>().text = Player.GetComponent<Player>().GetHeavenPointGet()+ "�o";
    }
}
