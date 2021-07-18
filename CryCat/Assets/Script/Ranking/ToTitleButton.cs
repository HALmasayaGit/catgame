using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleButton : MonoBehaviour
{
    public void OnClickTitleButton()
    {
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
