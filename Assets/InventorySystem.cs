using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<int, List<Item>> _itemList = new Dictionary<int, List<Item>>();

    private void Awake()
    {
        PlayerInteractController.OnAddInInvenotry += PlayerOnAddInInvenotry;
    }

    private void PlayerOnAddInInvenotry(Item item)
    {
        if(!_itemList.ContainsKey(item.id))
        {
            _itemList.Add(item.id, new List<Item>());
        }
        if (item.isSingleItem || _itemList[item.id].Count == 0)
        {
            _itemList[item.id].Add(item);
        }
        else
        {
            _itemList[item.id][0].count += item.count;
        }
    }
}
