using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField]
    private float Padding;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float ZoomSpeed;

    [SerializeField]
    private CinemachineVirtualCamera SwitchingviewPoint_1;

    [SerializeField]
    private PlayerController Player;

    [SerializeField]
    private Canvas starcraftUI;

    public CinemachineVirtualCamera cinemachine;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        SwitchingviewPoint_1 = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {

        MiniMapView();
        MiniMapZoom();
        MiniMapEscape();
    }

    private void MiniMapEscape()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

            cinemachine.enabled = false;
            SwitchingviewPoint_1.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            starcraftUI.enabled = false;
            Player.rtsMove = true;
    }
    private void MiniMapZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(ZoomSpeed * scroll * Vector3.forward * Time.deltaTime, Space.Self);
    }

    private void MiniMapView()
    {
            Vector2 pos = Input.mousePosition;
        if (0 <= pos.x && pos.x <= Padding) // 왼쪽 = 위 back
            transform.Translate(moveSpeed * Vector3.back * Time.deltaTime, Space.World);
        if (Screen.width - Padding <= pos.x && pos.x <= Screen.width ) // 오른쪽 = 아래forward
            transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime, Space.World);

        if (0 <= pos.y && pos.y <= Padding) // 아래 = 왼right
            transform.Translate(moveSpeed * Vector3.right * Time.deltaTime, Space.World);
        if (Screen.height - Padding <= pos.y && pos.y <= Screen.height) // 위 =오left
            transform.Translate(moveSpeed * Vector3.left * Time.deltaTime, Space.World);

    }
}

