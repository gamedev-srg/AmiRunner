using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Kills the player on contact with an obstacle object
 */
public class ObstacleKiller : MonoBehaviour
{
    PlayerMover playerMover;
    private void Start()
    {
        playerMover = GameObject.FindObjectOfType<PlayerMover>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMover.Kill();
        }
    }
}
