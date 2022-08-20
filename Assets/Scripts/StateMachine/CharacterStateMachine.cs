using System.Collections;
using UnityEngine;

public class CharacterStateMachine
{
    public CharacterState CurrentState { get; set; }

    public void Initialize(CharacterState startState)
    {
        CurrentState = startState;
    }

    public void ChangeState(CharacterState newState)
    {
        if(CurrentState != newState) CurrentState = newState;
        Debug.Log(CurrentState);
    }
}