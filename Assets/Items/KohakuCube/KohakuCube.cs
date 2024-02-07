using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KohakuCube : MonoBehaviour, IInteractable
{
    Inventory inv;
    public Transform trans;
    public Sprite sprite;
    public Item item;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    public string GetDescription()
    {
        return "Kohaku cube";
    }
    public void Interact()
    {
        trans.transform.Rotate(30, 0, 0);

        inv.AddItem(item);
        //Debug.Log(item.Name + " " + item.price);
    }
    public Sprite GetRenderer()
    {
        return sprite;
    }
}
