using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Main player mover and killer. This script will also restart the game via scene manager if the player dies
 */
public class PlayerMover : MonoBehaviour
{
    [Tooltip("Horizontal movement multiplier")]
    [SerializeField] float horizontalMultiplier = 3;
    [Tooltip("Player's global movement speed in meters per second")]
    [SerializeField] public float movementSpeed = 10;
    [Tooltip("Game horizontal limit, sets the games horizontal border that when reached will kill the player")]
    [SerializeField] public int horizontalGameBorder = -3;
    [Tooltip("Time to wait before restart on death")]
    [SerializeField] public int restartWaitTime = 1;
    [Tooltip("Player's rigid body component")]
    [SerializeField] Rigidbody rigidBody;
    /*    [Tooltip("players jump force")]
    [SerializeField] public float jumpForce = 400f;
    [Tooltip("Floor layer mask indication for jumping")]
    [SerializeField] LayerMask floorMask;
*/
    float horizontalInput;
    const int playerHeightHalver = 2;
    const float floorContactEpsilon = 0.1f;
    bool isAlive = true;

    /*
     * Constantly moves the player forward in a fixed rate each fixed time update
     * Also kills the player when coming into contact with obstacles and/or falling from the map
     */
    private void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
        Vector3 forwardMover = transform.forward * movementSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMover = transform.right * horizontalInput * movementSpeed * horizontalMultiplier * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + forwardMover + horizontalMover);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }*/
        if (transform.position.y < horizontalGameBorder)
        {
            Kill();
        }
    }

    public void Kill()
    {
        isAlive = false;
        Invoke("Restart", restartWaitTime);
    }

    /*
     * Restarts the game by restarting the current game scene
     */
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*
     * Used in order to initiate jumping, jumping will be disabled in this game version
     * 
/*    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / playerHeightHalver) + floorContactEpsilon, floorMask);
        rigidBody.AddForce(Vector3.up * jumpForce);
    }*/
}
