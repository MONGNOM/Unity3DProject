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

        string debug = playerView ? "1ÀÎÄª ÀüÈ¯" : "3ÀÎÄª ÀüÈ¯"; //ÀüÈ¯µÉ²¨ ? "true¿¡ ÂïÈú°Å" : "false¿¡ ÂïÈù°Å";  
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
            Debug.Log("°ü¸®ÀÚ ½ÃÁ¡À¸·Î ÀüÈ¯");
        }
    }
}
    

