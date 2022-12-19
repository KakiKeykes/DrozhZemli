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
    [SerializeField] private float _sneaktMultiplayer = 0.5f;
    [SerializeField] private InventorySystem _playerInvenory;
    [SerializeField] private CharacterStateController _characterStateCOntroller;
    [SerializeField] private bool _canRotate = true;
    [SerializeField] private Camera mainCamera;
    private int _layerMask;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Ground");
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
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(_playerInput.Player.MousePosition.ReadValue<Vector2>());
        if (_canRotate)
        {
            if(Physics.Raycast(ray, out hit, 10000, _layerMask))
            {
                var hitRotator = hit.point;
                hitRotator.y = this.transform.position.y;
                this.transform.rotation = Quaternion.LookRotation(hitRotator - transform.position, Vector3.up);
            }
        }

        Move(_playerInput.Player.Move.ReadValue<Vector2>());

        if (_characterStateCOntroller.stateMachine.CurrentState == CharacterState.Sprint)
        {
            if (_playerInput.Player.Sprint.WasPressedThisFrame())
            {
                ChangeSpeed(_sprintMultiplayer);
            }
        }
        if (_characterStateCOntroller.stateMachine.CurrentState == CharacterState.Walk)
        {
            _speed = _standartSpeed;
        }
        if (_characterStateCOntroller.stateMachine.CurrentState == CharacterState.Sneak)
        {
            if (_playerInput.Player.Sneak.WasPressedThisFrame())
            {
                ChangeSpeed(_sneaktMultiplayer);
            }
        }
    }

    private void Rotate(Vector2 rotateDirection)
    {
        this.transform.LookAt(new Vector3(rotateDirection.x, 0, rotateDirection.y));
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

    public InventorySystem GetInvontrySystem()
    {
        return _playerInvenory;
    }
}
