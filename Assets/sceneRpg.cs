using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneRpg : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            LodingSceneController.LoadScene("OrcCampScene");

        }




    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Rpg ������ �̵��մϴ�");
            LodingSceneController.LoadScene("GameRPG_Town");
        }
    }
}
