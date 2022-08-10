using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractConrtoller : MonoBehaviour
{
    public static event Action<Item, bool> OnAvailabilityInteractionItem;
    [SerializeField] private Item _item;

    private bool canInteract = false;

    public Transform playerTransfrom;
    [SerializeField] private float _interactionDistance = 1f;

    private void Update()
    {
        var isInInteractionDistance = (playerTransfrom.position - this.transform.position).sqrMagnitude <= _interactionDistance;
        if (isInInteractionDistance != canInteract)
        {
            canInteract = isInInteractionDistance;
            OnAvailabilityInteractionItem?.Invoke(_item, canInteract);
        }
    }
}