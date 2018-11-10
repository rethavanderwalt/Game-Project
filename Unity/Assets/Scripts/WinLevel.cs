using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour {

    PlayerController playerController;
    GameManager _gameManager;

    public bool wonLevel = false;
    public bool changedScene = false;
    private float _timeRemaining;


    public AudioSource winCluck;

    [SerializeField]
    private string newLevel;

    public float AnimationTimeRemaining
    {
        get { return _timeRemaining; }
        set { _timeRemaining = value; }
    }

    private float maxTimeAnimation = 1 * 3; // 3 seconds

	// Use this for initialization
	void Start () {
        playerController = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
        AnimationTimeRemaining = maxTimeAnimation;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (wonLevel == true)
        {
            // Time after winning before switching to next level
            AnimationTimeRemaining -= Time.deltaTime;
            // Once above timer reaches 0
            if (AnimationTimeRemaining <= 0)
            {
                // Switches to next level
                SceneManager.LoadScene(newLevel);
                changedScene = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            wonLevel = true;
            playerController.moveSpeed = 0f;
            winCluck.Play();
        }
        else { wonLevel = false; }
    }    
}
