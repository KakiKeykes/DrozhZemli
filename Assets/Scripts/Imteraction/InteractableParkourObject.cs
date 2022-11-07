using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableParkourObject : MonoBehaviour, IInteractable
{
    [SerializeField] private int _interactionDistance = 2;
    [SerializeField] private bool _canInteract = false;
    public int InteractionDistance => _interactionDistance;

    public GameObject InteractorGameObject => this.gameObject;
    public bool CanInteract { get => _canInteract; set => _canInteract = value; }

    public void Interact(PlayerController player)
    {
        Debug.Log("Parkour");
    }
    private void OnEnable()
    {
        InteractConrtoller.RegistrateInteractable(this);
    }
    private void OnDisable()
    {
        InteractConrtoller.DeregistrateInteractable(this);
    }
}
