using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text timerText;
    public float spawnWait;
    public float startWait;
    public Vector3 spawnValues;
    public GameObject positivePickUp;
    public GameObject negativePickUp;
    public GameObject timePickUp;

    private Rigidbody rb;
    private int count;
    private float timeLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeLeft = 30.0f;
        count = 0;
        SetCountText();
        timerText.text = "";
        StartCoroutine(SpawnPickups());
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        SetTimerText();
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick_up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("negative_pick_up"))
        {
            other.gameObject.SetActive(false);
            count--;
            SetCountText();
        }
        if (other.gameObject.CompareTag("time_pick_up"))
        {
            other.gameObject.SetActive(false);
            timeLeft += 5.0f;
            SetTimerText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    void SetTimerText()
    {
        timerText.text = "Time Left: " + Mathf.Round(timeLeft);
    }

    IEnumerator SpawnPickups()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Quaternion spawnRotation = Quaternion.identity;
            int pickUpDecider = Random.Range(0, 5);
            if (pickUpDecider == 1)
            {
                Instantiate(timePickUp, spawnPosition, spawnRotation);
            } else if (pickUpDecider == 2)
            {
                Instantiate(negativePickUp, spawnPosition, spawnRotation);
            } else
            {
                Instantiate(positivePickUp, spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }

}
