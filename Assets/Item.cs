using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable, IItem
{
    [SerializeField] private int _id;
    [SerializeField] private int _count = 1;
    [SerializeField] private int _maxCount = 2;
    [SerializeField] private bool _canInteract = false;
    [SerializeField] private int _interactionDistance = 2;

    public int Id => _id;
    public int MaxCount => _maxCount;
    public int Count { get => _count; set => _count = value; }
    public bool CanInteract { get => _canInteract; set => _canInteract = value; }
    public GameObject InteractorGameObject => this.gameObject;
    public int InteractionDistance => _interactionDistance;

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
        playerInvenotry.TryAdd(this);
    }
}
