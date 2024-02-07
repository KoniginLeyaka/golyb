using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumoCube : MonoBehaviour, IInteractable
{
    public Transform trans;
    public Sprite sprite;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    public string GetDescription()
    {
        return "Fumo cube";
    }
    public void Interact()
    {
        trans.transform.Rotate(30, 0, 0);
    }
    public Sprite GetRenderer()
    {
        return sprite;
    }
}
