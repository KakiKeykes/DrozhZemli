using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject, IItem
{
    [SerializeField] private int _maxCount = 2;
    public int MaxCount => _maxCount;
}
