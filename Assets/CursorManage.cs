using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.UI.Image;

public class CursorManage : MonoBehaviour
{
    public Texture2D Enter;
    public Texture2D orignal;


    public void CursorEnter()
    {
        Cursor.SetCursor(Enter, new Vector2(Enter.width / 3, 0), CursorMode.Auto);
    }

    public void CursorExit()
    {
        Cursor.SetCursor(orignal, new Vector2(0, 0), CursorMode.Auto);


    }


}
