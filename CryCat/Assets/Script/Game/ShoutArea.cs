using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutArea : MonoBehaviour
{
    [SerializeField, Header("大きくなる速度")] public float UpScaleSpeed = 0.1f;
    [SerializeField, Header("最大半径")] public float MaxRadian = 2.0f;
    [SerializeField, Header("無くなるまでの時間")] public float LifeTime = 1.0f;
    CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis", LifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.localScale.x < MaxRadian)
        {
            this.transform.localScale += new Vector3(UpScaleSpeed, UpScaleSpeed, 0);
        }
        if(this.transform.localScale.x >= MaxRadian)
        {
            this.transform.localScale = new Vector3(MaxRadian, MaxRadian, 0);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Cat")
        {
            collision.transform.GetComponent<Cat>().SetMoveFlg(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cat")
        {
            collision.transform.GetComponent<Cat>().SetMoveFlg(false);
        }
    }

    void DestroyThis()
    {
        this.transform.parent.transform.GetComponent<Player>().SetCryFlg(false);
        Destroy(this.gameObject);
    }
}
