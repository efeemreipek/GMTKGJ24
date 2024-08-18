using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private DayManager dayManager;

    public GameObject StartPanel;
    public GameObject InstructionsPanel;
    public GameObject PausePanel;
    public GameObject GamePanel;

    private void Awake()
    {
        dayManager = GetComponent<DayManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void StartGame()
    {
        if (!dayManager.GetIsGameStarted()) StartPanel.SetActive(false);
        else
        {
            PausePanel.SetActive(false);
            dayManager.PauseTime();
        }
        GamePanel.SetActive(true);
    }
    public void InstructionsButton()
    {
        StartPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
    }
    public void InstructionsButtonPause()
    {
        PausePanel.SetActive(false);
        InstructionsPanel.SetActive(true);
    }
    public void CloseButton()
    {
        InstructionsPanel.SetActive(false);
        if(!dayManager.GetIsGameStarted()) StartPanel.SetActive(true);
        else PausePanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (!dayManager.GetIsGameStarted()) return;
        if (PausePanel.activeInHierarchy) return;

        GamePanel.SetActive(false);
        PausePanel.SetActive(true);

        dayManager.PauseTime();
    }
}
