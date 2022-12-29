using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerViewr : MonoBehaviour
{
    [SerializeField]
    private float MouseSensitivity;

    [SerializeField]
    public Transform viewPoint1;
    [SerializeField]
    private Transform viewPoint3;

    [SerializeField]
    public GameObject SwitchingviewPoint_1;
    [SerializeField]
    public GameObject SwitchingviewPoint_3;

    [SerializeField]
    public GameObject SwitchingviewPoint_MiniMap;

    public PlayerController player;


    private float xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SwitchingviewPoint_MiniMap.SetActive(false);

    }

    private void Update()
    {
            Rotate();
            View();
    }

    private void View()
    {

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime);
    }

    private void Rotate()
    {

        xRotation -= Input.GetAxis("Mouse Y");
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        viewPoint1.localRotation = Quaternion.Euler(xRotation, 0, 0);
        viewPoint3.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("B키를 누르세요!");

        if (other.tag == "ViewPoint1")
        {
            SwitchingviewPoint_1.SetActive(true);
            SwitchingviewPoint_3.SetActive(false);
            Debug.Log("1인칭 시점으로 전환");

        }
        else if (other.tag == "ViewPoint3")
        {
            SwitchingviewPoint_1.SetActive(false);
            SwitchingviewPoint_3.SetActive(true);
            Debug.Log("3인칭 시점으로 전환");

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MiniMap" && Input.GetKeyDown(KeyCode.B))
        {
            SwitchingviewPoint_1.SetActive(false);
            SwitchingviewPoint_3.SetActive(false);
            SwitchingviewPoint_MiniMap.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.PlayerMove = false;
            Debug.Log("관리자 시점으로 전환");
        }
    }
}
    

