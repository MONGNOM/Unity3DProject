using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private GameObject SwitchingviewPoint_1;

    [SerializeField]
    private PlayerController Player;

    [SerializeField]
    private Canvas starcraftUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            SwitchingviewPoint_1.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Player.PlayerMove = true;
            starcraftUI.gameObject.SetActive(false);

        }

        MiniMapView();
        MiniMapZoom();
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

