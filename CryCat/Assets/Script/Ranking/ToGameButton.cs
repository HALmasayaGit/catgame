using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameButton : MonoBehaviour
{
    public void OnClickGameButton()
    {
        FadeManager.Instance.LoadScene("Game", 1.0f);
    }
}
