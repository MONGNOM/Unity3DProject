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
            Debug.Log("RTS�� �̵��մϴ�.");
            LodingSceneController.LoadScene("MainGameRTS");

        }
    }
}
