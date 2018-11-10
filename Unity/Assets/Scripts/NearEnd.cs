using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearEnd : MonoBehaviour
{

    PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerController.moveSpeed = 2f;
        }

    }
}
