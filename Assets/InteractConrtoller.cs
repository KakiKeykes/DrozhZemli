using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class InteractConrtoller : MonoBehaviour
    {
        internal static event Action<GameObject, bool> OnAvailabilityInteractionItem;

        internal bool canInteract = false;

        public Transform playerTransfrom;
        [SerializeField] private float _interactDistance = 1f;

        private void Update()
        {
            if ((playerTransfrom.position - this.transform.position).sqrMagnitude <= _interactDistance && !canInteract)
            {
                canInteract = true;
                OnAvailabilityInteractionItem?.Invoke(this.gameObject, canInteract);
            }
            else if ((playerTransfrom.position - this.transform.position).sqrMagnitude >= _interactDistance && canInteract)
            {
                canInteract = false;
                OnAvailabilityInteractionItem?.Invoke(this.gameObject, canInteract);
            }
        }
    }
}