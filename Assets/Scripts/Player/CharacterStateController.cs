using System.Collections;
using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();
    private PlayerInputActions _playerInput;
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

    void Start()
    {
        stateMachine.Initialize(CharacterState.Idle);
    }

    void Update()
    {
        if(stateMachine.CurrentState != CharacterState.Jump)
        {
            if(_playerInput.Player.Move.inProgress)
            {
                if(_playerInput.Player.Sprint.inProgress)
                {
                    stateMachine.ChangeState(CharacterState.Sprint);
                    return;
                }
                else if (_playerInput.Player.Sneak.inProgress)
                {
                    stateMachine.ChangeState(CharacterState.Sneak);
                    return;
                }
                stateMachine.ChangeState(CharacterState.Walk);
            }
            else
            {
                stateMachine.ChangeState(CharacterState.Idle);
            }
        }
    }
    private void Jump()
    {
        stateMachine.ChangeState(CharacterState.Jump);
        Debug.Log("Jump");
    }
}