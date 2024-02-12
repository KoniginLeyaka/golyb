using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KohakuCube : MonoBehaviour, IInteractable
{
    Inventory inv;
    private List<Item> inventory;
    public Transform trans;
    public Sprite sprite;
    public Item item;
    private GameObject player;
    void Start()
    {
        //trans = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        inv = player.GetComponent<Inventory>();
        inventory = inv.inventoryItems;
    }

    public string GetDescription()
    {
        return "Kohaku cube";
    }
    public void Interact()
    {
        //trans.transform.Rotate(30, 0, 0);

        inv.AddItem(item, ref inventory);
        //Debug.Log(item.Name + " " + item.price);
    }
    public Sprite GetRenderer()
    {
        return sprite;
    }
}