
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    PlayerController playerController;

    public AudioSource speedUpCluck;

    public float speedUp = 2f;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerController.moveSpeed < playerController.maxSpeed)
        {
            Destroy(gameObject);
            playerController.moveSpeed = playerController.moveSpeed + speedUp;
            speedUpCluck.Play();

        }
    }

}
