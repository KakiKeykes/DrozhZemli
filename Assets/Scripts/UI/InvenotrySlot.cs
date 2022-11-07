using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenotrySlot : MonoBehaviour
{
    [SerializeField] private Image image;

    public Image GetImage()
    {
        return image;
    }
}
