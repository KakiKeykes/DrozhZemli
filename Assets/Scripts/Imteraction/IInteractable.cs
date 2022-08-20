using UnityEngine;

public interface IInteractable
{
    public int InteractionDistance { get; }
    public GameObject InteractorGameObject { get; }
    public bool CanInteract { get; set; }
    public void Interact(PlayerController player);
}
