using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	// Use this for initialization
    public Text ScoreText;
    public Text timeText;
    public int score;
    public int time;

	void Start ()
	{
	    score = 0;
	    time = 0;
	    InvokeRepeating("updateScore", 1.0f, 0.5f);
       
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = "Score: " + score;
	    timeText.text = "Time: " + time;

	    if (time == 120)
	    {
	        Time.timeScale = 0;
	    }
        
	}

    void updateScore()
    {
        score += 3;
        time += 1;
    }
    
}
