using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float _speed = 1f;
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
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        navMeshAgent.Move(new Vector3(moveDirection.x, 0f, moveDirection.y) * _speed * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }
}
