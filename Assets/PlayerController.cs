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
    [SerializeField] private const float _standartSpeed = 3f;
    [SerializeField] private PlayerInputActions _playerInput;
    [SerializeField] private float _sprintMultiplayer = 2f;


    private void Awake()
    {
        _playerInput = new PlayerInputActions();
        _playerInput.Player.Jump.performed += context => Jump();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _speed = _standartSpeed;
    }

    void Update()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        Move(moveDirection);

        if(_playerInput.Player.Sprint.WasPressedThisFrame())
        {
            ChangeSpeed(_sprintMultiplayer);
        }

        if(_playerInput.Player.Sprint.WasReleasedThisFrame())
        {
            _speed = _standartSpeed;
        }
    }

    private void Move(Vector2 moveDirection)
    {
        navMeshAgent.Move(new Vector3(moveDirection.x, 0f, moveDirection.y) * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        Debug.Log("Jump");
    }

    private void ChangeSpeed(float speedMultuplayer)
    {
        _speed *= speedMultuplayer;
    }
}
