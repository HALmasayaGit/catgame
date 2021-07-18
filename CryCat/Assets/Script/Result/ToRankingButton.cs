using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRankingButton : MonoBehaviour
{
    public void OnClickRankingButton()
    {
        FadeManager.Instance.LoadScene("Ranking", 1.0f);
    }
}
