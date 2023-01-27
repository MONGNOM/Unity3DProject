using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    private StopButton stopButton;
    private void Start()
    {
        stopButton = FindObjectOfType<StopButton>();
    }
    public void startButton()
    {
        stopButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
