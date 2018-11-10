using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float _timeRemaining;

    PlayerController playerController;
    WinLevel winLevel;

    public float TimeRemaining
    {
        get { return _timeRemaining; }
        set { _timeRemaining = value; }
    }
    

    // Set timer values
    public float maxTime = 1 * 60; // 60 seconds
    
	// Use this for initialization
	void Start () {
        TimeRemaining = maxTime;

        // Find GameObjects
        playerController = FindObjectOfType<PlayerController>();
        winLevel = FindObjectOfType<WinLevel>();
    }
	
	// Update is called once per frame
	void Update () {
        if (winLevel.wonLevel == false)
        {
            // start timer
            TimeRemaining -= Time.deltaTime;
                
            if (TimeRemaining <= 0)
                {
                    // Restart level
                    Application.LoadLevel(Application.loadedLevel);
                    // Restart timer
                    TimeRemaining = maxTime;
                }
        }else if (winLevel.changedScene == true)
        {
            winLevel.wonLevel = false;
            TimeRemaining = maxTime;
            //winLevel.changedScene = false;
        }                
	}
}
