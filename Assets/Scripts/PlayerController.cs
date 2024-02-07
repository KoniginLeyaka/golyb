using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public bool isTerminal = false;
    private bool LightIsEnabled = true;
    private float mouseSens = 1f;
    [SerializeField] public int terminalInt;
    [SerializeField] public bool isGround;
    [SerializeField] bool crouch;
    [SerializeField] private Transform cameraTrans;

    private Animator animator;
    private Transform body;
    private Rigidbody rb;
    private float camStorage;
    [SerializeField] private float paramX = 1;
    [SerializeField] private float paramY = 1;
    private bool isRun;

    public void terminalSpeed(bool isTerminal)
    {
        if (!isTerminal)
        {
            terminalInt = 0;
            Debug.Log("0");
        }
        else
        {
            terminalInt = 1;
            Debug.Log("1");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        body = GetComponent<Transform>();
        isGround = true;
        terminalInt = 1;
    }
    // Update is called once per frame
    void run()
    {

    }
    void Update()
    {
        // crouch = false;
        // animator.SetBool("crouch", false);
        isRun = false;
        // paramY = 1;
        animator.SetFloat("x", Input.GetAxis("Vertical") * paramX);
        animator.SetFloat("y", Input.GetAxis("Horizontal") * paramY);

        if (!Input.GetKey(KeyCode.W))
        {
            paramX = Mathf.Lerp(paramX, 1f, Time.deltaTime * 7) * terminalInt;
        }


        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                isRun = true;
                paramX = Mathf.Lerp(paramX, 2f, Time.deltaTime * 11) * terminalInt;
                rb.transform.Translate(Vector3.forward * (speed + 2) * Time.deltaTime * terminalInt);
            }
            else
            {
                paramX = Mathf.Lerp(paramX, 1f, Time.deltaTime * 7) * terminalInt;
                rb.transform.Translate(Vector3.forward * speed * Time.deltaTime * terminalInt);
            }
        }

        // ›“Œ ¡Àﬂ“‹ ƒ¬»√¿≈“ Õ¿«¿ƒ Õ¿’”… ≈¡ÀŒ “€ “”œŒ≈

        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate(Vector3.back * (speed - 0.5f) * Time.deltaTime * terminalInt);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!isRun)
            {
                rb.transform.Translate(Vector3.right * speed * Time.deltaTime * terminalInt);
            } else paramY = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!isRun)
            {
                paramY = 0;
                rb.transform.Translate(Vector3.left * speed * Time.deltaTime * terminalInt);
            } else paramY = 0;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            paramX = 0;
            paramY = 0;
            animator.SetTrigger("crouch");
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
            animator.SetBool("crouch", true);
            //cameraTrans.Translate(Vector3.down * Time.deltaTime);
            //while (camStorage <= 0.455)
            //{
            //    cameraTrans.Translate(Vector3.down * Time.deltaTime);
            //    camStorage += -1 * Time.deltaTime;
            //}
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
            animator.SetBool("crouch", false);
        }

        float h = mouseSens * Input.GetAxis("Mouse X");

        body.Rotate(0, h, 0);
    }
}