using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera mycam;
    public GameObject groundMarker;

    public LayerMask clickable;
    public LayerMask ground;
    public int[,] snailArray;


    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);



            }
        }

        if ( Input.GetKey("a") && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }   

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    UnitSelection.Instance.ControlClickSelect(hit.collider.gameObject);

                }
                else
                {
                    UnitSelection.Instance.DeselectAll();
                    UnitSelection.Instance.ClickSelect(hit.collider.gameObject);
                }

            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                }
            
            }
        
        }

    }

        
}
