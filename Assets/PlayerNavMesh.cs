using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerNavMesh : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float speed = 1f;
    [SerializeField] private PlayerInputActions _playerInput;


    private void Awake()
    {
        _playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }



    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //navMeshAgent.destination = playerTransform.position + new Vector3(horizontal * speed, 0, vertical * speed);



        //if(NavMesh.SamplePosition(playerTransform.position + new Vector3(horizontal * speed, 0.1f, vertical * speed), out var hit, 1f, NavMesh.AllAreas))
        //{
        //    playerTransform.position = hit.position;
        //}

        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        navMeshAgent.Move(new Vector3(moveDirection.x, 0f, moveDirection.y) * speed * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }
}
