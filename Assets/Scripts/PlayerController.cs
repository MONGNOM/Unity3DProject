using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

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

    private PlayerViewr playerview;


    private float SpeedY;
    private CharacterController controller;


    private void Awake()
    {
        playerview = GetComponent<PlayerViewr>();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        PlayerMove = true;
    }
    private void Update()
    {
        if (!PlayerMove) return;
        else
        {
            Move();
            Jump();
        }
    }

    public void Move()
    {
        if (playerview.playerView) // 1인칭 이동 및 시점
        {
            controller.Move(transform.right * Input.GetAxis("Horizontal") * movespeed * Time.deltaTime);
            controller.Move(transform.forward * Input.GetAxis("Vertical") * movespeed * Time.deltaTime);
        }
        else                       // 3인칭 이동 및 시점
        {
            Vector3 forwardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;

            Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
            
            if (moveInput.sqrMagnitude > 1) moveInput.Normalize();

            Vector3 moveVec = forwardVec * moveInput.z + rightVec * moveInput.x;

            controller.Move(moveVec * movespeed * Time.deltaTime);

            if (moveVec.sqrMagnitude != 0) transform.forward = Vector3.Lerp(transform.forward, moveVec, 0.8f);
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))    SpeedY = JumpPower;
        else if (controller.isGrounded)     SpeedY = 0;
        else                                SpeedY += Gravity * Time.deltaTime;

        controller.Move(Vector3.up * SpeedY * Time.deltaTime);
    }
}
