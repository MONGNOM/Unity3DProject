using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : SingleTon<Scene>
{
    private sceneRpg sceneRpg;

    private Canvas startcraftView;
    private void Awake()
    {
        sceneRpg = GetComponent<sceneRpg>();

    }
   
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("RTS�� �̵��մϴ�.");
            SceneManager.LoadScene("MainGameRTS");
    }
}
