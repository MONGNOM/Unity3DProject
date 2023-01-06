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
    public GameObject SwitchingviewPoint_1;
    [SerializeField]
    public GameObject SwitchingviewPoint_3;

    [SerializeField]
    public GameObject SwitchingviewPoint_MiniMap;

    [SerializeField]
    private Canvas starcraftUI;
    

    public PlayerController player;

    public bool playerView;


    private float xRotation = 0;

   


    private void Start()
    {
        playerView = true;
        view = Playerview.view1;
        Cursor.lockState = CursorLockMode.Locked;
        SwitchingviewPoint_MiniMap.SetActive(false);
        starcraftUI.gameObject.SetActive(false);
    }

   
    private void Update()
    {
            Rotate();
            View();
            Test();
       
    }
    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ChangedView();
    }
     
    private void View()
    {
        if (view == Playerview.view1) transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime);
        
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
            SwitchingviewPoint_1.SetActive(true);
            SwitchingviewPoint_3.SetActive(false);
            playerView = !playerView;

        }
        else
        {
            SwitchingviewPoint_1.SetActive(false);
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
            SwitchingviewPoint_1.SetActive(false);
            SwitchingviewPoint_3.SetActive(false);
            SwitchingviewPoint_MiniMap.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.PlayerMove = false;
            starcraftUI.gameObject.SetActive(true);
            Debug.Log("°ü¸®ÀÚ ½ÃÁ¡À¸·Î ÀüÈ¯");
        }
    }
}
    

