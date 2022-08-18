using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Slot[] _slots;
    [SerializeField] private int _inventorySlotsCount;

    private void Start()
    {
        _slots = new Slot[_inventorySlotsCount];
    }

    public bool TryAdd(Item item)
    {
        for(int i = 0; i < _inventorySlotsCount; i++)
        {
            if (_slots[i].ItemID == 0)
            {
                _slots[i].ItemID = item.Id;
                _slots[i].Count = item.Count;
                return true;
            }
            else if(_slots[i].ItemID == item.Id && _slots[i].Count < item.MaxCount)
            {
                if (_slots[i].Count + item.Count <= item.MaxCount)
                {
                    _slots[i].Count += item.Count;
                    return true;
                }
                else
                {
                    item.Count = item.Count + _slots[i].Count - item.MaxCount;
                    _slots[i].Count = item.MaxCount;
                }
            }
        }
        InvenoryIsFull();
        return false;
    }

    private void InvenoryIsFull()
    {
        Debug.Log("Invenory is full");
    }

    public bool TryRemove(int slotIndex, int count)
    {
        var slot = _slots[slotIndex];
        if (count <= slot.Count)
        {
            slot.Count -= count;
            if (slot.Count == 0)
                ClearSlot(slotIndex);
            return true;
        }
        return false;
    }

    private void ClearSlot(int slotIndex)
    {
        _slots[slotIndex].Count = 0;
        _slots[slotIndex].ItemID = 0;
    }
}

public struct Slot
{
    public int ItemID;  
    public int Count;
}