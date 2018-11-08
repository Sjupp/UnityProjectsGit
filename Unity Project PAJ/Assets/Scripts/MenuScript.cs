using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    public GameObject Startbutton;
    public GameObject HowToPlaybutton;
    public GameObject Settingsbutton;
    public GameObject Aboutbutton;
    public GameObject Quitbutton;
    public GameObject QuitPromptthing;

    GameObject[] menubuttons;

    public Text SettingsText;
    bool settings = false;

    public Text SubtitlesText;
    bool subtitles = false;

    // Use this for initialization
    void Start () {

        menubuttons =  new GameObject[] { Startbutton, HowToPlaybutton, Settingsbutton, Aboutbutton, Quitbutton};
        SubtitlesText.text = "Subtitles: disabled";
        SettingsText.text = "Working buttons: off";

    }
	
    public void ButtonPress(int arg1)
    {
        for (int i = 0; i < menubuttons.Length; i++)
        {
            if (menubuttons[i] == menubuttons[arg1])
            {
                menubuttons[i].SetActive(true);

                if (menubuttons[i] == menubuttons[0])
                {
                    SceneManager.LoadScene(1);
                }
                else if (menubuttons[i] == menubuttons[4])
                {
                    QuitPromptthing.SetActive(true);
                }
            }
            else
            {
                menubuttons[i].SetActive(false);
            }
        }
    }

    public void QuitPrompt(string input)
    {
        if (input == "yes")
        {
            Debug.Break();
        }
        else
        {
            QuitPromptthing.SetActive(false);
            menubuttons[4].SetActive(false);
        }
    }

    public void Settings()
    {
        if (!settings)
        {
            SettingsText.text = "Working buttons: nope";
            settings = true;
        }
        else
        {
            SettingsText.text = "Working buttons: off";
            settings = false;
        }
    }

    public void Subtitles()
    {
        if (!subtitles)
        {
            SubtitlesText.text = "Subtitles: enabled";
            subtitles = true;
        }
        else
        {
            SubtitlesText.text = "Subtitles: disabled";
            subtitles = false;
        }
    }
}
