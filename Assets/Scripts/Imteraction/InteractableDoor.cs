using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private int _interactionDistance = 2;
    [SerializeField] private bool _canInteract = false;
    [SerializeField] private Item _key;


    public int InteractionDistance => _interactionDistance;

    public GameObject InteractorGameObject => this.gameObject;

    public bool CanInteract { get => _canInteract; set => _canInteract = value; }

    private void OnEnable()
    {
        InteractConrtoller.RegistrateInteractable(this);
    }
    private void OnDisable()
    {
        InteractConrtoller.DeregistrateInteractable(this);
    }
    public void Interact(PlayerController player)
    {
        //переделать шоб он не сразу удалял айтем
        var playerInvenotry = player.GetInvontrySystem();
        if(playerInvenotry.GetItemCount(_key) > 0)
        {
            Debug.Log("Interact");
            playerInvenotry.TryRemoveItem(_key, 1);
        }
    }

}
