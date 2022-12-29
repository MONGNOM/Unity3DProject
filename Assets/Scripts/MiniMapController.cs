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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            SwitchingviewPoint_1.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Player.PlayerMove = true;
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
        if (0 <= pos.x && pos.x <= Padding) // ����
            transform.Translate(moveSpeed * Vector3.right * Time.deltaTime, Space.World);
        if (Screen.width - Padding <= pos.x && pos.x <= Screen.width ) // ������
            transform.Translate(moveSpeed * Vector3.left * Time.deltaTime, Space.World);

        if (0 <= pos.y && pos.y <= Padding) // �Ʒ�
            transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime, Space.World);
        if (Screen.height - Padding <= pos.y && pos.y <= Screen.height) // ��
            transform.Translate(moveSpeed * Vector3.back * Time.deltaTime, Space.World);

    }
}

