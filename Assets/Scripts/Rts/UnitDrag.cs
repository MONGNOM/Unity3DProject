using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera mycam;

    [SerializeField]
    RectTransform boxVisual;

    Rect seclectionBox;

    Vector2 startPosition;
    Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            seclectionBox = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();

        }

    }

    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxsize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxsize;
    }

    void DrawSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            seclectionBox.xMin = Input.mousePosition.x;
            seclectionBox.xMax = startPosition.x;
        }
        else
        {
            seclectionBox.xMin = startPosition.x;
            seclectionBox.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < startPosition.y)
        {
            seclectionBox.yMin = Input.mousePosition.y;
            seclectionBox.yMax = startPosition.y;
        }
        else
        {
            seclectionBox.yMin = startPosition.y;
            seclectionBox.yMax = Input.mousePosition.y;
        }
    }
    void SelectUnits()
    {
        foreach (var unit in UnitSelection.Instance.unitList)
        {
            if (seclectionBox.Contains(mycam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitSelection.Instance.DragSelect(unit);
            }
        }
    }
}
