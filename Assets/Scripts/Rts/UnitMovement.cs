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
    public Animator anim;

    [SerializeField]
    public PlayerViewr playerview;
   

    ICommandable buttonS, buttonH, buttonA, buttona;

    public NavMeshAgent Agent { get { return agent; } set { agent = value; } }



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
        playerview = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerViewr>();
        agent = GetComponent<NavMeshAgent>();
        teamMonster = GetComponent<TeamMonster>();

        buttonS = new StopMoveCommand(this,teamMonster);
        buttonH = new HoldMoveCommand(this,teamMonster);
        buttonA = new AttackMoveCommand(this, teamMonster);
        buttona = new Attackmarine(teamMonster,this);
    }

    // Update is called once per frame
    void Update()
    {
        MoveStop();

        if (!playerview.playerView)
            return;

        if (Input.GetKeyDown("s")) buttonS.Execute();
        else if (Input.GetKeyDown("h")) buttonH.Execute();
        else if (Input.GetKey("a") && Input.GetMouseButtonDown(0))
        {
            buttonA.Execute();
            buttona.Execute();
        }
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
                teamMonster.marine = true;
                agent.enabled = true;
                agent.isStopped = false;
                detination = hit.point;
                agent.destination = detination;
                anim.SetTrigger("Walk");
                Debug.Log("몬스터가 출발합니다.");
            }

        }

        if (!playerview.playerView)
            return;

        if (Input.GetKey("a") && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.enabled = true;
                teamMonster.marine = true;
                agent.isStopped = false;
                detination = hit.point;
                agent.destination = detination;
                anim.SetTrigger("Walk");
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
           // Debug.Log("몬스터가 목적지를 잃었다.");
        }
    }

    




}
