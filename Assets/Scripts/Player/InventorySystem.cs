using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Slot[] _slots;
    [SerializeField] private int _inventorySlotsCount;
    public event Action<Slot, int> OnItemAdded;
    public event Action<int> OnItemRemoved;

    private void Start()
    {
        _slots = new Slot[_inventorySlotsCount];
    }

    public bool TryAdd(Item item, int count)
    {
        for(int i = 0; i < _inventorySlotsCount; i++)
        {
            if (_slots[i].Item == null)
            {
                _slots[i].Item = item;
                _slots[i].Count = count;
                OnItemAdded?.Invoke(_slots[i], i);
                return true;
            }
            else if(_slots[i].Item == item && _slots[i].Count < item.MaxCount)
            {
                if (_slots[i].Count + count <= item.MaxCount)
                {
                    _slots[i].Count += count;
                    OnItemAdded?.Invoke(_slots[i], i);
                    return true;
                }
                else
                {
                    count = count + _slots[i].Count - item.MaxCount;
                    _slots[i].Count = item.MaxCount;
                    OnItemAdded?.Invoke(_slots[i], i);
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
            OnItemRemoved?.Invoke(slotIndex);
            return true;
        }
        return false;
    }

    private void ClearSlot(int slotIndex)
    {
        _slots[slotIndex].Count = 0;
        _slots[slotIndex].Item = null;
    }

    public Item GetItemFromSlot(int slotIndex)
    {
        return _slots[slotIndex].Item;
    }

    public int GetCountFromSlot(int slotIndex)
    {
        return _slots[slotIndex].Count;
    }
    public int GetInventorySlotsCount()
    {
        return _inventorySlotsCount;
    }
    public int GetKey(int _keyID)
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            if(_slots[i].Item.keyID == _keyID)
            {
                return i;
            }    
        }
        return -1;
    }
}

public struct Slot
{
    public Item Item;  
    public int Count;
}