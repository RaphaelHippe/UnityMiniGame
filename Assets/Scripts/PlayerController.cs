using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    /*
     * PUBLIC Class Variables
     */
    public float speed;
    public GameObject gameController;

    /*
     * PRIVATE Class Variables
     */

    private Rigidbody rb;

    /*
     * UNITY Methods
     */

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);
        rb.AddForce(movement * speed);
    }

    /*
     * PRIVATE Class Methods
     */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("positive_pick_up"))
        {
            gameController.GetComponent<GameController>().collideYellow(other);
        }
        if (other.gameObject.CompareTag("negative_pick_up"))
        {
            gameController.GetComponent<GameController>().collideRed(other);
        }
        if (other.gameObject.CompareTag("time_pick_up"))
        {
            gameController.GetComponent<GameController>().collideGreen(other);
        }
        if (other.gameObject.CompareTag("speed_pick_up"))
        {
            gameController.GetComponent<GameController>().collideOrange(other);
        }
        if (other.gameObject.CompareTag("reset_pick_up"))
        {
            gameController.GetComponent<GameController>().collideBlack(other);
        }
    }

    /*
     * PUBLIC Class Methods
     */

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float getSpeed()
    {
        return speed;
    }

}
