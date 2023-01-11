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
        Debug.Log("Rpg 맵으로 이동합니다");
        SceneManager.LoadScene("GameRPG_Town");
    }
}
