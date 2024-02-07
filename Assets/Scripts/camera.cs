using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сamera : MonoBehaviour
{
    public Transform cam;
    public bool opportunityRotate;
    public bool topEdge;
    public bool bottomEdge;
    [SerializeField] private float camRotate;
    [SerializeField] private float camStorage;
    void Start()
    {
        cam = GetComponent<Transform>();
        opportunityRotate = true;
        topEdge = false;
        bottomEdge = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }
    void Update()
    {
        Vector3 arrow = new Vector3((camRotate * -1), 0, 0);
        cam.Rotate(arrow * (Time.deltaTime * 150));
        if (opportunityRotate)
        {
            camRotate = Input.GetAxis("Mouse Y");
            camStorage += camRotate * (Time.deltaTime * 150);
            cam.Rotate(arrow * (Time.deltaTime * 150));
        }
        if (!opportunityRotate && topEdge)
        {
            cam.Rotate(Vector3.right * (Time.deltaTime * 150));
            camStorage += Vector3.right.x * (Time.deltaTime * 150) * -1;
        } else if (!opportunityRotate && bottomEdge)
        {
            cam.Rotate(Vector3.left * (Time.deltaTime * 150));
            camStorage += Vector3.left.x * (Time.deltaTime * 150) * -1;
        }
        if (camStorage >= 90)
        {
            opportunityRotate = false;
            topEdge = true;
        } else if (camStorage <= -90)
        {
            opportunityRotate = false;
            bottomEdge = true;
        } else
        {
            opportunityRotate = true;
            bottomEdge = false;
            topEdge = false;
        }
    }
}
//Голубь лох объелся блох