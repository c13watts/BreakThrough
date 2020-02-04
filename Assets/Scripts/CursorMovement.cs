﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CursorMovement : MonoBehaviour {

    //private int playerPaused;
    public int P1Color;
    public int P2Color;
    private float speed;
    public bool isPaused;
    public bool P1Selected;
    public bool P2Selected;
    public bool P1Ready;
    public bool P2Ready;
    private bool start;

    private string p1Cross = "Cross_P1";
    private string p1Circle = "Circle_P1";
    private string p1Hor = "Horizontal_P1";
    private string p1Ver = "Vertical_P1";
    private string p2Cross = "Cross_P2";
    private string p2Circle = "Circle_P2";
    private string p2Hor = "Horizontal_P2";
    private string p2Ver = "Vertical_P2";

    public GameObject backMenuUI;
    public GameObject P1Cursor;
    public GameObject P2Cursor;
    public GameObject fightButton;
    public GameObject loadingScreen;
    public GameObject P1ColorSelect;
    public GameObject P2ColorSelect;
    public GameObject P1ReadyText;
    public GameObject P2ReadyText;

    public CursorDetection P1;
    public CursorDetection P2;

    void Start()
    {
        Time.timeScale = 1;

        p1Cross += UpdateControls(CheckXbox(0));
        p2Cross += UpdateControls(CheckXbox(1));
        p1Circle += UpdateControls(CheckXbox(0));
        p2Circle += UpdateControls(CheckXbox(1));
        p1Ver += UpdateControls(CheckXbox(0));
        p1Hor += UpdateControls(CheckXbox(0));
        p2Ver += UpdateControls(CheckXbox(1));
        p2Hor += UpdateControls(CheckXbox(1));
    }

    void Update()
    {
        //Set cursor speed to be constant with resolution
        speed = Screen.width / 1.5f;

        //Manage Back Menu interations
        if (isPaused == false)
        {
            if (!P1.P1Selected)
            {
                //Manage P1Cursor movement
                float x = Input.GetAxis(p1Hor);
                float y = Input.GetAxis(p1Ver);

                P1Cursor.transform.position += new Vector3(x, y, 0) * 1/50 * speed;

                P1Cursor.transform.position = new Vector3(Mathf.Clamp(P1Cursor.transform.position.x, Screen.width / 100, Screen.width),
                Mathf.Clamp(P1Cursor.transform.position.y, Screen.height / 20, Screen.height),
                P1Cursor.transform.position.z);
            }
            if (!P2.P2Selected)
            {
                //Manage P2Cursor movement
                float x2 = Input.GetAxis(p2Hor);
                float y2 = Input.GetAxis(p2Ver);

                P2Cursor.transform.position += new Vector3(x2, y2, 0) * 1/50 * speed;

                P2Cursor.transform.position = new Vector3(Mathf.Clamp(P2Cursor.transform.position.x, Screen.width / 100, Screen.width),
                Mathf.Clamp(P2Cursor.transform.position.y, Screen.height / 20, Screen.height),
                P2Cursor.transform.position.z);
            }
        }

        //P1 MENUS
        //Bring up P1 Color Select Menu
        if (P1.P1Selected && !P1Ready)
        {
            P1ColorSelect.SetActive(true);

            //Receive P1 inputs for color select
            if (Input.GetAxis(p1Hor) < 0)
            {
                P1ColorSelect.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "< 1 >";
   
            }
            else if (Input.GetAxis(p1Hor) > 0)
            {
                P1ColorSelect.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "< 2 >";
            }

            //Check for P1 confirmation
            if (Input.GetButtonDown(p1Cross))
            {
                switch (P1ColorSelect.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text)
                {
                    case "< 1 >":
                        P1Color = 1;
                        break;

                    case "< 2 >":
                        P1Color = 2;
                        break;
                }

                //Check to ensure no colors are the same
                if (GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Character == GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Character)
                {
                    if ((P1Color == 0 && P2Color == 0) || P1Color != P2Color)
                    {
                        GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Color = P1Color;
                        P1Ready = true;
                        P1ColorSelect.SetActive(false);
                    }                 
                }
                else
                {
                    GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Color = P1Color;
                    P1Ready = true;
                    P1ColorSelect.SetActive(false);
                }
            }
        }
        else
        {
            P1ColorSelect.SetActive(false);
        }

        //Deselect P1 from Color Menu
        if (Input.GetButtonDown(p1Circle) && P1Ready)
        {
            P1Color = 0;
            P1Ready = false;
            P1ColorSelect.SetActive(true);
        }

        //Set Ready Text
        if (P1Ready && !start)
        {
            P1ReadyText.SetActive(true);
        }
        else
        {
            P1ReadyText.SetActive(false);
        }

        //Check for character selection
        if (P1.isOverlap)
        {
            if (Input.GetButtonDown(p1Cross))
            {
                P1.P1Selected = true;
                GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Character = P1.currentChar;
            }
        }

        //P2 MENUS
        //Bring up P2 Color Select Menu
        if (P2.P2Selected && !P2Ready)
        {
            P2ColorSelect.SetActive(true);

            //Receive P2 inputs for color select
            if (Input.GetButtonDown(p2Hor) && Input.GetAxis(p2Hor) < 0)
            {
                P2ColorSelect.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "< 1 >";
            }
            else if (Input.GetButtonDown(p2Hor) && Input.GetAxis(p2Hor) > 0)
            {
                P2ColorSelect.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "< 2 >";
            }

            //Check for P2 confirmation
            if (Input.GetButtonDown(p2Cross))
            {
                switch (P2ColorSelect.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text)
                {
                    case "< 1 >":
                        P2Color = 1;
                        break;

                    case "< 2 >":
                        P2Color = 2;
                        break;
                }

                //Check to ensure colors are not the same
                if (GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P1Character == GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Character)
                {
                    if ((P1Color == 0 && P2Color == 0) || P1Color != P2Color)
                    {
                        GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Color = P2Color;
                        P2Ready = true;
                        P2ColorSelect.SetActive(false);
                    }
                }
                else
                {
                    GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Color = P2Color;
                    P2Ready = true;
                    P2ColorSelect.SetActive(false);
                }
            }
        }
        else
        {
            P2ColorSelect.SetActive(false);
        }

        //Deselect P2 from Color Menu
        if (Input.GetButtonDown(p2Circle) && P2Ready)
        {
            P2Color = 0;
            P2Ready = false;
            P2ColorSelect.SetActive(true);
        }

        //Set Ready Text
        if (P2Ready && !start)
        {
            P2ReadyText.SetActive(true);
        }
        else
        {
            P2ReadyText.SetActive(false);
        }

        //Check for character selection
        if (P2.isOverlap)
        {
            if (Input.GetButtonDown(p2Cross))
            {
                P2.P2Selected = true;
                GameObject.Find("PlayerData").GetComponent<SelectedCharacterManager>().P2Character = P2.currentChar;
            }
        }

        //Bring up Fight button once both players are ready
        if (P1Ready && P2Ready)
        {
            StartGame();
        }
        else
        {
            fightButton.SetActive(false);
        }

        //Manage Back Menu (Figure out later)
        /* if (isPaused)
         {
             ActivateMenu();
             //Unpause the game (Only the player that paused can unpause)
             if (Input.GetButtonDown(p1Circle) && playerPaused == 1)
             {
                 isPaused = !isPaused;
                 playerPaused = 0;
             }
             if (Input.GetButtonDown(p2Circle) && playerPaused == 2)
             {
                 isPaused = !isPaused;
                 playerPaused = 0;
             }
         }
         else if (!isPaused)
         {
             DeactivateMenu();
             //Record which player paused
             if (Input.GetButtonDown(p1Circle) && playerPaused == 0 && !P1.P1Selected)
             {
                 isPaused = !isPaused;
                 playerPaused = 1;
             }
             if (Input.GetButtonDown(p2Circle) && playerPaused == 0 && !P2.P2Selected)
             {
                 isPaused = !isPaused;
                 playerPaused = 2;
             }
         }*/
    }

    public void ActivateMenu()
     {
         backMenuUI.SetActive(true);
     }

     public void DeactivateMenu()
     {
         backMenuUI.SetActive(false);
         isPaused = false;
         //playerPaused = 0;
     }

    public void StartGame()
    {
        loadingScreen.SetActive(true);
        P1ReadyText.SetActive(false);
        P2ReadyText.SetActive(false);
        start = true;
        SceneManager.LoadScene(3);
    }

     public void QuitToMenu()
     {
         SceneManager.LoadScene(0);
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
