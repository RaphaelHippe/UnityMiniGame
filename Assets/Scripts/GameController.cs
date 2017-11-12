using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    /*
     * PUBLIC Class Variables
     */

    public Text countText;
    public Text timerText;
    public float spawnWait;
    public float startWait;
    public Vector3 spawnValues;
    public GameObject positivePickUp;
    public GameObject negativePickUp;
    public GameObject timePickUp;
    public GameObject speedPickUp;
    public GameObject resetPickUp;
    public GameObject player;

    /*
     * PRIVATE Class Variables
     */

    private int points,
        positivePickUps,
        negativePickUps,
        timePickUps,
        speedPickUps,
        resetPickUps;
    private float timeLeft,
        currentPlayerSpeed;
    private bool isCurrentlyBoosted;

    /*
     * UNITY Methods
     */

    private void Start()
    {
        points = 0;
        timeLeft = 30.0f;
        isCurrentlyBoosted = false;
        updateCounterText();
        StartCoroutine(SpawnPickups());
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        setTimerText();
        if (timeLeft < 0)
        {

            GameStats.Points = points;
            GameStats.PositivePickUps = positivePickUps;
            GameStats.NegativePickUps = negativePickUps;
            GameStats.TimePickUps = timePickUps;
            GameStats.SpeedPickUps = speedPickUps;
            GameStats.ResetPickUps = resetPickUps;
            SceneManager.LoadScene("GameOver");
        }
    }

    /*
     * PRIVATE Class Methods
     */

    private void updateCounterText()
    {
        countText.text = "Points: " + points.ToString();
    }

    private void setTimerText()
    {
        timerText.text = "Seconds: " + timeLeft.ToString(); 
    }

    private IEnumerator SpawnPickups()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Quaternion spawnRotation = Quaternion.identity;
            /*
             * 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
             * yellow / positive: 6, 7, 8, 9
             * red / negative: 3, 4, 5
             * green / time: 1, 2
             * orange / speed: 0
             * black / reset: 10
             */
            int pickUpDecider = Random.Range(0, 11);
            

            if (pickUpDecider == 0)
            {
                createCopy(speedPickUp, spawnPosition, spawnRotation, "speed_pick_up");
            } else if (pickUpDecider >= 1 && pickUpDecider <= 2)
            {
                createCopy(timePickUp, spawnPosition, spawnRotation, "time_pick_up");
            } else if (pickUpDecider >= 3 && pickUpDecider <= 5)
            {
                createCopy(negativePickUp, spawnPosition, spawnRotation, "negative_pick_up");
            } else if (pickUpDecider == 10)
            {
                createCopy(resetPickUp, spawnPosition, spawnRotation, "reset_pick_up");
            } else
            {
                createCopy(positivePickUp, spawnPosition, spawnRotation, "positive_pick_up");
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void createCopy(GameObject obj, Vector3 spawnPosition, Quaternion spawnRotation, string tag)
    {
        GameObject createdCopy;
        createdCopy = Instantiate(obj, spawnPosition, spawnRotation);
        createdCopy.tag = tag;
    }

    private void resetPlayerSpeed()
    {
        player.GetComponent<PlayerController>().setSpeed(currentPlayerSpeed);
        isCurrentlyBoosted = false;
    }

    /*
     * PUBLIC Class Methods
     */

    public void collideYellow(Collider other)
    {
        other.gameObject.SetActive(false);
        //GameObject.Destroy(other);
        points++;
        positivePickUps++;
        updateCounterText();
    }

    public void collideRed(Collider other)
    {
        other.gameObject.SetActive(false);
        //GameObject.Destroy(other);
        points--;
        negativePickUps++;
        updateCounterText();
    }

    public void collideGreen(Collider other)
    {
        other.gameObject.SetActive(false);
        //GameObject.Destroy(other);
        timeLeft += 5.0f;
        timePickUps++;
    }

    public void collideOrange(Collider other)
    {
        other.gameObject.SetActive(false);
        //GameObject.Destroy(other);

        if(!isCurrentlyBoosted)
        {
            isCurrentlyBoosted = true;
            speedPickUps++;
            currentPlayerSpeed = player.GetComponent<PlayerController>().getSpeed();
            player.GetComponent<PlayerController>().setSpeed(currentPlayerSpeed * 2);
            Invoke("resetPlayerSpeed", 5);
        }
    }

    public void collideBlack(Collider other)
    {
        other.gameObject.SetActive(false);
        resetPickUps++;
        GameObject[] negativePickUps = GameObject.FindGameObjectsWithTag("negative_pick_up");
        foreach(GameObject pickup in negativePickUps)
        {
            pickup.gameObject.SetActive(false);
        }
    }





}
