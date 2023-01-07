using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent ChangeView;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        ChangeView?.Invoke();
    }
}
