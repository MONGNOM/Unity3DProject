using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneRpg : MonoBehaviour
{
    private Scene scene;

    private void Awake()
    {
        scene = GetComponent<Scene>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Rpg ������ �̵��մϴ�");
        SceneManager.LoadScene("GameRPG_Town");
    }
}
