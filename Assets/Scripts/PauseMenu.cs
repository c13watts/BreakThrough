﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{

    public GameOver GameOver;

    public GameObject pauseMenuUI;
    public GameObject moveListUI;
    public bool isPaused;
    static public bool pauseQuit;
    public bool moveList;
    private int playerPaused;

    private string pauseCode1 = "Start_P1";
    private string pauseCode = "Start_P2";

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        playerPaused = 0;

        pauseCode1 += UpdateControls(CheckXbox(0));
        pauseCode += UpdateControls(CheckXbox(1));

        pauseQuit = false;
        moveList = false;
        moveListUI.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (isPaused)
        {
            //Disable player inputs in background
            DisableControls(true);
            ActivateMenu();
            //Record which player paused
            if (Input.GetButtonDown(pauseCode1) && playerPaused == 1)
            {
                isPaused = !isPaused;
                playerPaused = 0;
            }
            if (Input.GetButtonDown(pauseCode) && playerPaused == 2)
            {
                isPaused = !isPaused;
                playerPaused = 0;
            }
        }
        else if (!isPaused)
        {
            DisableControls(false);
            DeactivateMenu();
            //Unpause the game (Only the player that paused can unpause)
            if (Input.GetButtonDown(pauseCode1) && playerPaused == 0)
            {
                isPaused = !isPaused;
                playerPaused = 1;
            }
            if (Input.GetButtonDown(pauseCode) && playerPaused == 0)
            {
                isPaused = !isPaused;
                playerPaused = 2;
            }
        }
    }

    private void DisableControls(bool enable)
    {
        GameObject FPC = GameObject.FindWithTag("Player");
        FPC.transform.GetComponent<AttackHandlerDHA>().enabled = !enable;
        FPC.transform.GetComponent<MovementHandler>().enabled = !enable;
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        if (!moveList)
        {
            pauseMenuUI.SetActive(true);
            moveListUI.SetActive(false);
        } 
        else
        {
            moveListUI.SetActive(true);
            pauseMenuUI.SetActive(false);
        }
            
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        playerPaused = 0;
    }

    public void MoveList()
    {
        pauseMenuUI.SetActive(false);
        moveList = true;
        //moveListUI.SetActive(true);
    }

    public void MoveListBack()
    {
        moveList = false;
        moveListUI.SetActive(false);
    }

    public void QuitToMenu()
    {
        StartText.startReady = false;
        GameOver.lockInputs = false;
        GameOver.p1Win = 0;
        GameOver.p2Win = 0;
        pauseQuit = true;

        //Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    private bool CheckXbox(int player)
    {
        if (Input.GetJoystickNames().Length > player)
        {
            if (Input.GetJoystickNames()[player].Contains("Xbox"))
            {
                return true;
            }
        }
        return false;
    }

    private string UpdateControls(bool xbox)
    {
        if (xbox)
            return "_Xbox";
        return "";
    }
}
