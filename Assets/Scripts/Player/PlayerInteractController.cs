using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    [SerializeField] private List<IInteractable> _interactorList = new List<IInteractable>();
    [SerializeField] private PlayerInputActions _playerInput;
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        InteractConrtoller.OnAvailabilityInteractionItem += PlayerOnAvailabilityInteractionItem;

        _playerInput = new PlayerInputActions();

        _playerInput.Player.Interact.performed += context => InteractItem();
        _playerInput.Player.RollItem.performed += context => RollItem();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    private void OnDestroy()
    {
        InteractConrtoller.OnAvailabilityInteractionItem -= PlayerOnAvailabilityInteractionItem;
    }

    private void PlayerOnAvailabilityInteractionItem(IInteractable interactor)
    {
        if (interactor.CanInteract)
        {
            AddItem(interactor);
        }
        else
        {
            RemoveItem(interactor);
        }
    }

    private void AddItem(IInteractable interactor)
    {
        if (_interactorList.Contains(interactor))
        {
            return;
        }
        _interactorList.Add(interactor);
    }

    private void RemoveItem(IInteractable interactor)
    {
        if (_interactorList.Contains(interactor))
        {
            _interactorList.Remove(interactor);
        }
    }

    private void InteractItem()
    {
        if (_interactorList.Count > 0)
        {
            _interactorList[0].Interact(_playerController);
        }
    }

    private void RollItem()
    {
        if (_interactorList.Count > 0)
        {
            _interactorList.Add(_interactorList[0]);
            _interactorList.RemoveAt(0);
        }
    }
}