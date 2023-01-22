using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IInterActionadpter : MonoBehaviour, IInteractable
{
    public UnityEvent<PlayerController> OnInteraction;

    public void InterAction(PlayerController player)
    {
        OnInteraction?.Invoke(player);  
    }   
}
