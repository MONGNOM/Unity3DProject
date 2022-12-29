using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movespeed;

    [SerializeField]
    private float JumpPower;

    [SerializeField]
    private float Gravity;

    public bool PlayerMove = true;


    private float SpeedY;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        PlayerMove = true;
    }
    private void Update()
    {
        if (!PlayerMove)
            return;
        else
        {
            Move();
            Jump();
        }
       
        
    }

    public void Move()
    {
        controller.Move(transform.right *Input.GetAxis("Horizontal") * movespeed * Time.deltaTime);
        controller.Move(transform.forward * Input.GetAxis("Vertical") * movespeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            SpeedY = JumpPower;
        else if (controller.isGrounded)
            SpeedY = 0;
        else
            SpeedY += Gravity * Time.deltaTime;

        controller.Move(Vector3.up * SpeedY * Time.deltaTime);
    }
}
