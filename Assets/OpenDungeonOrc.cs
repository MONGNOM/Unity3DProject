using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDungeonOrc : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("오크마을로 갑니다.");
            LodingSceneController.LoadScene("OrcCampScene");
        }
    }

}
