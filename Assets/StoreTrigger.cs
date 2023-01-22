using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoreTrigger : MonoBehaviour
{
    public StoreUi store;
    public PlayerViewr controller;
    private void Awake()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerViewr>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controller.ChangedView();
        }
    }



}
