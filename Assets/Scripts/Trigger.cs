using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public PlayerViewr controller;
    public UnityEvent ChangeView;
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
