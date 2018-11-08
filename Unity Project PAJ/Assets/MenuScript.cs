using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public GameObject Startbutton;
    public GameObject HowToPlaybutton;
    public GameObject Settingsbutton;
    public GameObject Aboutbutton;
    public GameObject Quitbutton;
    public GameObject QuitPromptthing;

    GameObject[] menubuttons;

    // Use this for initialization
    void Start () {

        menubuttons =  new GameObject[] { Startbutton, HowToPlaybutton, Settingsbutton, Aboutbutton, Quitbutton};

	}
	
    public void ButtonPress(int arg1)
    {
        for (int i = 0; i < menubuttons.Length; i++)
        {
            if (menubuttons[i] == menubuttons[arg1])
            {
                menubuttons[i].SetActive(true);
                if (menubuttons[i] == menubuttons[4])
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
        }
    }
}
