using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : SingleTon<Scene>
{
 
private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("RTS로 이동합니다.");
            LodingSceneController.LoadScene("MainGameRTS");

        }
    }
}
