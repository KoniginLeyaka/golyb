using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Terminal : MonoBehaviour, IInteractable
{
    public Transform trans;
    public Sprite sprite;
    private bool isOpen = false;
    private bool isOpened = false;
    [SerializeField] GameObject terminal;
    private string terminalText = "Golyb loh os started at 0.6ms",terminalText2;
    private string memory;
    private bool isStarted = false;
    private bool LightIsEnabled = true;
    private bool LightMaster = false;
    [SerializeField] Light PurpleLight;
    [SerializeField] GameObject Door;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] private Behaviour scriptContoller;
    [SerializeField] private Behaviour scriptCamera;
    [SerializeField] Animator Animator;
    void Start()
    {
        trans = GetComponent<Transform>();
        terminal.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            terminal.SetActive(false);
            scriptContoller.enabled = true;
            //scriptCamera.enabled = true;
            isOpen = false;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UseTerminal(inputField.text, ref LightMaster);
        }
    }
    private void UseTerminal(string command, ref bool LightMaster)
    {
        switch(command)
        {
            case "sudo Light off":
                if (LightMaster && !LightIsEnabled)
                {
                    terminalText += "\nThe light system is already turned off";
                    text.SetText(terminalText);
                }
                else if (LightMaster && LightIsEnabled)
                {
                    terminalText += "\nLight System is off";
                    text.SetText(terminalText);
                    EnabledLight(ref LightIsEnabled);
                }
                if (!LightMaster)
                {
                    terminalText += "\nError: LightMaster is not installed";
                    text.SetText(terminalText);
                }
                break;
            case "sudo Light on":
                if (LightMaster && LightIsEnabled)
                {
                    terminalText += "\nThe light system is already turned on";
                    text.SetText(terminalText);
                } else if (LightMaster && !LightIsEnabled)
                {
                    terminalText += "\nLight System is on";
                    text.SetText(terminalText);
                    EnabledLight(ref LightIsEnabled);
                }
                if (!LightMaster)
                {
                    terminalText += "\nError: LightMaster is not installed";
                    text.SetText(terminalText);
                }
                break;
            case "apt-get install LightMaster":
                LightMaster = true;
                terminalText += "\nLightMaster is installed";
                text.SetText(terminalText);
                Door.SetActive(false);
                break;
            case "sudo DoorTestOpen":
                Animator.SetBool("isOpen", false);
                Debug.Log("Door is open");
                break;
            default:
                terminalText += "\nError 404.";
                text.SetText(terminalText);
                break;
        }
    }
    private void EnabledLight(ref bool LightIsEnabled)
    {
        LightIsEnabled = !LightIsEnabled;
        PurpleLight.enabled = LightIsEnabled;
    }
    public string GetDescription()
    {
        return "Terminal";
    }
    public void Interact()
    {
        if (!isOpen)
        {
            terminal.SetActive(true);
            isOpen = true;
            scriptContoller.enabled = false;
            //scriptCamera.enabled = false;
            Debug.Log("console start");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (!isOpened)
            {
                isOpened = true;
                StartCoroutine(StartTerminal());
            }
        }
    }
    public Sprite GetRenderer()
    {
        return sprite;
    }
    public IEnumerator StartTerminal()
    {
        yield return new WaitForSeconds(1f);
        terminalText += "\n\nMain Processor: Intel 4004 5GGhz";
        text.SetText(terminalText);
        yield return new WaitForSeconds(1f);
        terminalText2 += "\n\nChecking memory: ";
        for (int i = 0; i <= 32768; i += 4096)
        {
            memory = i.ToString();
            text.SetText(terminalText + terminalText2 + memory + " MB is OK");
            yield return new WaitForSeconds(0.5f);
        }
        terminalText += terminalText2 + memory + " MB is OK";
        text.SetText(terminalText);
        yield return new WaitForSeconds(1f);
        terminalText += "\n\nMemory Frequenzy is at 12600 MHz, Four Channel Mode"; 
        text.SetText(terminalText);
        yield return new WaitForSeconds(1f);
        terminalText += "\n\tPrimary Master : FUMOPUPPER SDU0234\n\tPrimary Slave : FUMOPUPPER QQR";
        text.SetText(terminalText);
        yield return new WaitForSeconds(0.5f);
        terminalText += "\n\tSecond Master : FUMOPUPPER SDU0234\n\tSecond Slave : FUMOPUPPER QQR";
        text.SetText(terminalText);
        yield return new WaitForSeconds(0.5f);
        terminalText += "\n\tThird Master : FUMOPUPPER SDU0234\n\tThird Slave : FUMOPUPPER QQR";
        text.SetText(terminalText);
        yield return new WaitForSeconds(0.5f);
        terminalText += "\n\tFourth Master : FUMOPUPPER SDU0234\n\tFourth Slave : FUMOPUPPER QQR";
        text.SetText(terminalText);
    }
}
