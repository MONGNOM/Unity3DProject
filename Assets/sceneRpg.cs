using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneRpg : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            LodingSceneController.LoadScene("GameRPG_Town");

        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            LodingSceneController.LoadScene("MainGameRTS");
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Rpg 맵으로 이동합니다");
            LodingSceneController.LoadScene("GameRPG_Town");
        }
    }
}
