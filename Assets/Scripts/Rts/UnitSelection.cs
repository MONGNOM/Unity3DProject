using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitSelection : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>(); 
    public List<GameObject> unitSelected = new List<GameObject>();


    public Vector3 destiantion;
    private static UnitSelection instance;

    public static UnitSelection Instance { get { return instance; }}



    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        { 
            instance = this;
            
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    { 
        DeselectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }

    public void ControlClickSelect(GameObject unitToAdd)
    {
        if (!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;

        }
        else
        {
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitToAdd.transform.GetChild(3).gameObject.SetActive(false);
            unitSelected.Remove(unitToAdd);
        }

    }
    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
            // 드래그 선택 하나만 할 수 있게 초기화 하는 방법 생각하기
        }

    }

    public void DeselectAll()
    {
        foreach (var unit in unitSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(3).gameObject.SetActive(false);
        }
        unitSelected.Clear();
    }

    public void DeSelect(GameObject unitToDeselect)
    {

    }
}
