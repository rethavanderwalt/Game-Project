using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immobilise : MonoBehaviour {

    private PlayerController _playerController;
    private GameManager _gameManager;

    public bool immobilised;
    private float maxImmoTime = 1 * 5; // 5 seconds
    private float _immoTimeTRemaining;

    public float ImmoTimeRemaining
    {
        get { return _immoTimeTRemaining; }
        set { _immoTimeTRemaining = value; }
    }

    public AudioSource immobilisedCluck;


    // Use this for initialization
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
        ImmoTimeRemaining = maxImmoTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (immobilised == true)
        {

            // start timer
            ImmoTimeRemaining -= Time.deltaTime;
            

            if (ImmoTimeRemaining <= 0)
            {
                // Resets Immobilise timer
                ImmoTimeRemaining = maxImmoTime;
                _playerController.moveSpeed = 3f;

                // Stop timer
                immobilised = false;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.gameObject.name == "Player")
        {
            immobilised = true;
            StopPlayer();
            immobilisedCluck.Play();

        }
        else { immobilised = false; }
    }

    void ImmobiliseTimeOut()
    {
        _playerController.moveSpeed = 3f;
    }

    void StopPlayer()
    {
        _playerController.moveSpeed = 0f;
    }
}