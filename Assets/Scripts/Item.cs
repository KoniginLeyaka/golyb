using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Items")]
public class Item : ScriptableObject
{
    public string Name = "Item";
    public Texture Texture;
    public int price = 10;
    public GameObject itemObject;
}