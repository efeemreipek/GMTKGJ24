using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static Action OnGameRestarted;

    private DayManager dayManager;

    public GameObject StartPanel;
    public GameObject InstructionsPanel;
    public GameObject PausePanel;
    public GameObject GamePanel;
    public GameObject EndLosePanel;
    public GameObject EndWinPanel;

    private bool isGameWon = false;

    private void Awake()
    {
        dayManager = GetComponent<DayManager>();

        DayManager.OnGameOver += DayManager_OnGameOver;
        DayManager.OnGameWon += DayManager_OnGameWon;
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

        dayManager.ChangeIsGameStarted(true);

        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab, 0.5f);
    }
    public void InstructionsButton()
    {
        StartPanel.SetActive(false);
        InstructionsPanel.SetActive(true);

        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab, 0.5f);
    }
    public void InstructionsButtonPause()
    {
        PausePanel.SetActive(false);
        InstructionsPanel.SetActive(true);

        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab, 0.5f);
    }
    public void CloseButton()
    {
        InstructionsPanel.SetActive(false);
        if(!dayManager.GetIsGameStarted()) StartPanel.SetActive(true);
        else PausePanel.SetActive(true);

        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab, 0.5f);
    }
    public void RestartGame()
    {
        if(isGameWon) EndWinPanel.SetActive(false);
        else EndLosePanel.SetActive(false);

        StartPanel.SetActive(true);

        OnGameRestarted?.Invoke();

        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab, 0.5f);
        AudioManager.Instance.StopBackgroundMusic(false);
    }
    public void QuitGame()
    {
        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab, 0.5f);

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
    private void DayManager_OnGameOver()
    {
        GamePanel.SetActive(false);
        EndLosePanel.SetActive(true);

        isGameWon = false;
    }
    private void DayManager_OnGameWon()
    {
        GamePanel.SetActive(false);
        EndWinPanel.SetActive(true);

        isGameWon = true;
    }
}
