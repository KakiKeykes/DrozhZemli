using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenoryUI : MonoBehaviour
{
    [SerializeField] private InventorySystem playerInventory;
    [SerializeField] private List<Image> slotsImage = new List<Image>();
    [SerializeField] private InvenotrySlot slotPrefab;

    private void Awake()
    {
        playerInventory.OnItemAdded += InvenoryUIOnItemAdded;
        playerInventory.OnItemRemoved += InvenoryUIOnItemRemoved;
    }

    private void OnDestroy()
    {
        playerInventory.OnItemAdded -= InvenoryUIOnItemAdded;
        playerInventory.OnItemRemoved -= InvenoryUIOnItemRemoved;
    }

    private void Start()
    {
        for(int i = 0; i < playerInventory.GetInventorySlotsCount(); i++)
        {
            InvenotrySlot newSlot = Instantiate(slotPrefab, this.transform);
            slotsImage.Add(newSlot.GetImage());
        }
    }

    private void InvenoryUIOnItemAdded(Slot slot, int index)
    {
        slotsImage[index].sprite = slot.Item.ItemSprite;
    }

    private void InvenoryUIOnItemRemoved(int index)
    {
        slotsImage[index].sprite = null;
    }
}
