using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

enum Playerview { view1,veiw3 }

public class PlayerViewr : MonoBehaviour
{
    [SerializeField]
    private Playerview view;

    [SerializeField]
    private float MouseSensitivity;

    [SerializeField]
    public Transform viewPoint1;
    [SerializeField]
    private Transform viewPoint3;

    [SerializeField]
    public CinemachineVirtualCamera SwitchingviewPoint_1;
    [SerializeField]
    public GameObject SwitchingviewPoint_3;

    [SerializeField]
    public CinemachineVirtualCamera SwitchingviewPoint_MiniMap;
    


    [SerializeField]
    private Canvas starcraftUI;

    [SerializeField]
    private GameObject playerModel;

    public PlayerController player;

    public bool playerView;


    private float xRotation = 0;


    private void Awake()
    {
        SwitchingviewPoint_MiniMap = GameObject.Find("MiniMap_Cam").GetComponent<CinemachineVirtualCamera>();
        SwitchingviewPoint_1 = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        starcraftUI = GameObject.Find("StarCraftCanvus").GetComponent<Canvas>();

    }
    private void Start()
    {
        SwitchingviewPoint_MiniMap = GameObject.Find("MiniMap_Cam").GetComponent<CinemachineVirtualCamera>();
        starcraftUI = GameObject.Find("StarCraftCanvus").GetComponent<Canvas>();
        playerModel.SetActive(false);
        SwitchingviewPoint_3.SetActive(false);
        playerView = true;
        view = Playerview.view1;
        Cursor.lockState = CursorLockMode.Locked;
        SwitchingviewPoint_MiniMap.enabled = false;
        starcraftUI.enabled = false;
    }

   
    private void Update()
    {
        // 계속 업데이트에서 찾아주면 안되니까 씬 전환이 RTS로 넘어올때 가져와야함
        // 매니저 업데이트에 있는 친구들 다 바꿔줘야함 안그럼 2스테이지 가면 터질듯 ㅋㅋ
            //SwitchingviewPoint_MiniMap = GameObject.Find("MiniMap_Cam").GetComponent<CinemachineVirtualCamera>();
            //starcraftUI = GameObject.Find("StarCraftCanvus").GetComponent<Canvas>();

        Rotate();
         View();
         Test();
    }
    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.Q)) ChangedView();
    }
     
    private void View()
    {
        if (view == Playerview.view1) transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime);
        else transform.forward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
        
    }

    private void Rotate()
    {
        if (view == Playerview.view1)
        {
            xRotation -= Input.GetAxis("Mouse Y");
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);
            viewPoint1.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
    }

    public void ChangedView()
    {
       
        if (!playerView)
        {
            SwitchingviewPoint_1.enabled =true;
            playerModel.SetActive(false);
            SwitchingviewPoint_3.SetActive(false);
            playerView = !playerView;

        }
        else
        {
            SwitchingviewPoint_1.enabled = false;
            playerModel.SetActive(true);
            SwitchingviewPoint_3.SetActive(true);
            playerView = !playerView;
        }

        string debug = playerView ? "1인칭 전환" : "3인칭 전환"; //전환될꺼 ? "true에 찍힐거" : "false에 찍힌거";  
        Debug.Log(debug);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MiniMap" && Input.GetKey("b"))
        {
            SwitchingviewPoint_1.enabled = false;
            SwitchingviewPoint_3.SetActive(false);
            SwitchingviewPoint_MiniMap.enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            starcraftUI.enabled = true;
            player.rtsMove = false;
            Debug.Log("관리자 시점으로 전환");
        }
    }
}
    

