using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public GameObject Startbutton;
    public GameObject HowToPlaybutton;
    public GameObject Settingsbutton;
    public GameObject Aboutbutton;
    public GameObject Quitbutton;

    GameObject[] menubuttons;

    // Use this for initialization
    void Start () {

        menubuttons =  new GameObject[] { Startbutton, HowToPlaybutton, Settingsbutton, Aboutbutton, Quitbutton};

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPress(int arg1)
    {
        for (int i = 0; i < menubuttons.Length; i++)
        {
            if (menubuttons[i] == menubuttons[arg1])
            {
                menubuttons[i].SetActive(true);
                Debug.Log("Button: " + menubuttons[i] + " pressed.");
            }
            else
            {
                menubuttons[i].SetActive(false);
            }
        }
        Debug.Log("1");
    }
}
