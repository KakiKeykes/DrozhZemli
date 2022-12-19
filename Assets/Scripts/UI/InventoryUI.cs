using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySystem playerInventory;
    [SerializeField] private List<Image> slotsImage = new List<Image>();
    [SerializeField] private InventorySlot slotPrefab;

    private void Awake()
    {
        playerInventory.OnItemAdded += InventoryUIOnItemAdded;
        playerInventory.OnItemRemoved += InventoryUIOnItemRemoved;
    }

    private void OnDestroy()
    {
        playerInventory.OnItemAdded -= InventoryUIOnItemAdded;
        playerInventory.OnItemRemoved -= InventoryUIOnItemRemoved;
    }

    private void Start()
    {
        for(int i = 0; i < playerInventory.GetInventorySlotsCount(); i++)
        {
            InventorySlot newSlot = Instantiate(slotPrefab, this.transform);
            slotsImage.Add(newSlot.GetImage());
        }
    }

    private void InventoryUIOnItemAdded(Slot slot, int index)
    {
        slotsImage[index].sprite = slot.Item.ItemSprite;
    }

    private void InventoryUIOnItemRemoved(int index)
    {
        slotsImage[index].sprite = null;
    }
}
