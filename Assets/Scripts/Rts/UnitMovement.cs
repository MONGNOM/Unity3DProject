using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(NavMeshAgent))]

public class UnitMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public int placeSize;
    public Vector3 detination;
    public LayerMask ground;
    public TeamMonster teamMonster;
    
   

    ICommandable buttonS, buttonH, buttonA;

    public NavMeshAgent Agent { get { return agent; } set { agent = value; } }


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        teamMonster = GetComponent<TeamMonster>();

        buttonS = new StopMoveCommand(this,teamMonster);
        buttonH = new HoldMoveCommand(this,teamMonster);
        buttonA = new AttackMoveCommand(this,teamMonster);
    }

    // Update is called once per frame
    void Update()
    {
        MoveStop();

        if (Input.GetKeyDown("s")) buttonS.Execute();
        else if (Input.GetKeyDown("h")) buttonH.Execute();
        else if (Input.GetKey("a") && Input.GetMouseButtonDown(0)) buttonA.Execute();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.enabled = true;
                agent.isStopped = false;
                detination = hit.point;
                agent.destination = detination;
                Debug.Log("몬스터가 출발합니다.");
            }

        }
        if (Input.GetKey("a") && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.enabled = true;
                agent.isStopped = false;
                detination = hit.point;
                agent.destination = detination;
                Debug.Log("몬스터가 출발합니다.");
            }
        }

    }

    public void MoveStop()
    {
        Vector3 offset = transform.position * 6f - detination * 6f;
        float sqrlen = offset.sqrMagnitude;

        if (sqrlen < agent.speed * agent.speed)
        {
            teamMonster.attack = true;
            agent.ResetPath();
            agent.velocity = Vector3.zero;
            Debug.Log("몬스터가 목적지를 잃었다.");
        }
    }

    




}
