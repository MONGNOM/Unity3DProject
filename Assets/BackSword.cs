using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackSword : MonoBehaviour
{
    public UnityEvent HideSword;
    public UnityEvent ShowSword;

    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 14 && player.playerBattle)
        {
            Debug.Log("Ä®À» »Ì¾Ò´Ù");
            ShowSword?.Invoke();
        }
        else if(other.gameObject.layer == 14 && !player.playerBattle)
        {
            Debug.Log("Ä®À» ³Ö¾ú´Ù");
            HideSword?.Invoke();
        }



    }
}
