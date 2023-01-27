using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene("MainGameRTS");
    }

    public void EndButton()
    {
         Application.Quit();
    }
}
