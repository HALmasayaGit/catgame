using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    // �|�C���g��\������Text�^
    public Text pointText;
    // �v���C���[�̓��ꕨ
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pointText.text = Player.GetComponent<Player>().GetHeavenPoint().ToString() + "�w�u��";
    }
}
