
using UnityEngine;

public class SlowDown : MonoBehaviour
{

    PlayerController playerController;

    public AudioSource slowDownCluck;

    public float slowDown = -2f;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerController.moveSpeed < playerController.maxSpeed)
        {
            Destroy(gameObject);
            playerController.moveSpeed = playerController.moveSpeed + slowDown;
            slowDownCluck.Play();

        }
    }

}
