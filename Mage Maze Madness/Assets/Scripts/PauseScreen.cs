﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject PBGD;
    public GameObject Pause;
    public GameObject Resume;
    public GameObject Options;
    public GameObject MainMenu;
    public GameObject Volume;
    public GameObject Back;
    // Start is called before the first frame update
    void Start()
    {
        PBGD.SetActive(false);
        Pause.SetActive(false);
        Resume.SetActive(false);
         Options.SetActive(false);
         MainMenu.SetActive(false);
         Volume.SetActive(false);
         Back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            PBGD.SetActive(true);
            Pause.SetActive(true);
            Resume.SetActive(true);
             Options.SetActive(true);
             MainMenu.SetActive(true);
             Volume.SetActive(false);
             Back.SetActive(false);
        }
    }
    public void OnClick()
    {

    }
    public void ResumeGame()
    {
        Cursor.visible = false;
        PBGD.SetActive(false);
        Pause.SetActive(false);
        Resume.SetActive(false);
        Options.SetActive(false);
        MainMenu.SetActive(false);
        Volume.SetActive(false);
        Back.SetActive(false);
    }
    public void VolumeClick()
    {
        PBGD.SetActive(true);
        Pause.SetActive(false);
        Resume.SetActive(false);
        Options.SetActive(false);
        MainMenu.SetActive(false);
        Volume.SetActive(true);
        Back.SetActive(true);
    }
    public void GoBack()
    {
        PBGD.SetActive(true);
        Pause.SetActive(true);
        Resume.SetActive(true);
        Options.SetActive(true);
        MainMenu.SetActive(true);
        Volume.SetActive(false);
        Back.SetActive(false);
    }
    public void MainClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
    }
