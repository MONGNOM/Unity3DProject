using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomePortal : MonoBehaviour
{
    //  ��������
    public Transform rpgTown;
    public PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.transform.position = rpgTown.position;
            Debug.Log("Rpg ������ �̵��մϴ�");
         
        }
    }
}
