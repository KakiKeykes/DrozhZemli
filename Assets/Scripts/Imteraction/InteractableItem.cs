using System.Collections;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField] private int _interactionDistance = 2;
    [SerializeField] private int _count = 1;
    [SerializeField] private bool _canInteract = false;
    [SerializeField] private Item _item;


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

        var playerInvenotry = player.GetInvontrySystem();
        playerInvenotry.TryAdd(_item, _count);
    }
}