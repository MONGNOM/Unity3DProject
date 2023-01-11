using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneRpg : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Rpg 맵으로 이동합니다");
            LodingSceneController.LoadScene("GameRPG_Town");
        }
    }
}
