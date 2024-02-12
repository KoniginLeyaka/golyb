using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public Sprite sprite;
    public Item item;

    public int maxItems = 6;
    [SerializeField] List<Item> startItems = new List<Item>();
    public List<Item> inventoryItems = new List<Item>();
    [SerializeField] GameObject[] playerHotbarArray;
    [SerializeField] GameObject scroller;

    float mouseWheel;
    int currentItem;
    void Start()
    {
        currentItem = 0;
        for (int i = 0; i < startItems.Count; i++)
        {
            AddItem(startItems[i], ref inventoryItems);
        }
    }

    void Update()
    {
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel < -0.1)
        {
            if (currentItem >= 6) currentItem =- 1;
            scroller.transform.SetParent(playerHotbarArray[currentItem + 1].transform);
            scroller.transform.position = new Vector2(playerHotbarArray[currentItem + 1].transform.position.x, scroller.transform.position.y);
            currentItem++;
            Debug.Log(currentItem);
        }

        if (mouseWheel > 0.1)
        {
            if (currentItem == 0) currentItem = 1;
            scroller.transform.SetParent(playerHotbarArray[currentItem - 1].transform);
            scroller.transform.position = new Vector2(playerHotbarArray[currentItem - 1].transform.position.x, scroller.transform.position.y);
            currentItem--;
            Debug.Log(currentItem);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(item, ref inventoryItems);
        }
    }
    void Redraw()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            playerHotbarArray[i].GetComponent<RawImage>().color = new Color(255,255,255,255);
            Texture iconTexture = inventoryItems[i].Texture;
            playerHotbarArray[i].GetComponent<RawImage>().texture = iconTexture;
        }
    }
    public void AddItem(Item item, ref List<Item> inventory) {
        if (inventory.Count < maxItems) {
            inventory.Add(item);
            Redraw();
        }
    }
}
