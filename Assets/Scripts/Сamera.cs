using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform cum;
    [SerializeField] private float cumRotate;
    [SerializeField] private float cumStorage;
    void Start()
    {
        cum = GetComponent<Transform>();
        cumStorage = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        cumRotate = Input.GetAxis("Mouse Y") * (Time.deltaTime * 150);

        cumStorage += cumRotate;
        cumStorage = Mathf.Clamp(cumStorage, -53f, 85f);
        transform.localRotation = Quaternion.Euler(cumStorage * -1, 0f, 0f);
    }
}
//Голубь лох объелся блох