using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Use this for initialization
    public Text sText;
    public Text tText;
    
    void Start ()
    {
        sText.text = "Score: " + ((int)PlayerPrefs.GetFloat("Score")).ToString();
        tText.text = "Time: " + ((int)PlayerPrefs.GetFloat("Time")).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
