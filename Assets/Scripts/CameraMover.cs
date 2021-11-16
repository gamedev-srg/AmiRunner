using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Makes the camera lock on the player and follow constantly
 * Also makes sure the camera always stays in the middle by setting the cameras x position to constant zero
 */
public class CameraMover : MonoBehaviour
{
    [Tooltip("Player's object for the camera to lock onto")]
    [SerializeField] Transform playerObject;
    Vector3 playerCameraDistance;
    const int onstantHorizontalSetter = 0;

    /*
     * Calculates the current distance between the camera and the player
     */
    private void Start() 
    {
        playerCameraDistance = transform.position - playerObject.position;
    }

    private void Update()
    {
        Vector3 nextCameraPosition = playerObject.position + playerCameraDistance;
        nextCameraPosition.x = onstantHorizontalSetter;
        transform.position = nextCameraPosition;
    }
}
