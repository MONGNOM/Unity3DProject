using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    public PlayerController player;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //player.transform.position = gameObject.transform.position;
    }

    private void Start()
    {
        //player.transform.position = gameObject.transform.position;
    }

    


}
