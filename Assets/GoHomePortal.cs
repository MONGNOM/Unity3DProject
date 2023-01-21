using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomePortal : MonoBehaviour
{
    //  ��������
    public string enterScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            SceneManager.LoadScene("OrcCampScene");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Rpg ������ �̵��մϴ�");
            SceneManager.LoadScene(enterScene);
        }
    }
}
