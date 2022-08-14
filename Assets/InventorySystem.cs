using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<int, List<Item>> _itemList = new Dictionary<int, List<Item>>();


    public void AddInInvenotry(Item item)
    {
        if(!_itemList.ContainsKey(item.Id))
        {
            _itemList.Add(item.Id, new List<Item>());
        }
        if (item.IsSingleItem || _itemList[item.Id].Count == 0)
        {
            _itemList[item.Id].Add(item);
        }
        else
        {
            _itemList[item.Id][0].Count += item.Count;
        }
    }
}
