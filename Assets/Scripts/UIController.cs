using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject joinRoom;
    [SerializeField] GameObject createRoom;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject exit;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject acceptSettings;
    [SerializeField] GameObject backSettings;
    [SerializeField] private int numberScene;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    public void BtnJoinRoom()
    {
        SceneManager.LoadScene(numberScene);
    }

    public void BtnCreateRoom()
    {

    }

    public void BtnSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void BtnAcceptSettings() 
    {
        
    }

    public void BtnBackSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void BtnExit()
    {
        Application.Quit();
    }
}
