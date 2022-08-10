using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    [SerializeField] private List<Item> _itemInteract = new List<Item>();
    [SerializeField] private PlayerInputActions _playerInput;

    public static event Action<Item> OnAddInInvenotry;

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

    private void PlayerOnAvailabilityInteractionItem(Item _itemGameObject, bool canInteract)
    {
        if (canInteract)
        {
            AddItem(_itemGameObject);
        }
        else
        {
            RemoveItem(_itemGameObject);
        }
    }

    private void AddItem(Item itemGameObject)
    {
        if (_itemInteract.Contains(itemGameObject))
        {
            return;
        }
        _itemInteract.Add(itemGameObject);
    }

    private void RemoveItem(Item itemGameObject)
    {
        if (_itemInteract.Contains(itemGameObject))
        {
            _itemInteract.Remove(itemGameObject);
        }
    }

    private void InteractItem()
    {
        if (_itemInteract.Count > 0)
        {
            OnAddInInvenotry?.Invoke(_itemInteract[0]);
        }
    }

    private void RollItem()
    {
        if (_itemInteract.Count > 0)
        {
            _itemInteract.Add(_itemInteract[0]);
            _itemInteract.RemoveAt(0);
        }
    }
}