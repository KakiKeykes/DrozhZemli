using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _itemInteract = new List<GameObject>();
        [SerializeField] private PlayerInputActions _playerInput;

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

        private void PlayerOnAvailabilityInteractionItem(GameObject _itemGameObject, bool canInteract)
        {
            if (canInteract)
            {
                Debug.Log(canInteract);
                AddItem(_itemGameObject);
            }
            else
            {
                Debug.Log(canInteract);
                RemoveItem(_itemGameObject);
            }
        }

        private void AddItem(GameObject itemGameObject)
        {
            foreach (GameObject item in _itemInteract)
            {
                if (item == itemGameObject)
                {
                    return;
                }
            }
            _itemInteract.Add(itemGameObject);
        }

        private void RemoveItem(GameObject itemGameObject)
        {
            foreach (GameObject item in _itemInteract)
            {
                if (item == itemGameObject)
                {
                    _itemInteract.Remove(itemGameObject);
                    return;
                }
            }
        }

        private void InteractItem()
        {
            if (_itemInteract.Count > 0)
            {
                Debug.Log("Interact with ", _itemInteract[0]);
            }
        }

        private void RollItem()
        {
            if (_itemInteract.Count > 0)
            {
                var _item = _itemInteract[0];
                _itemInteract.Remove(_item);
                _itemInteract.Add(_item);
            }
        }
    }
}