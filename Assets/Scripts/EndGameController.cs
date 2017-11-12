using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    /*
     * PUBLIC Class Variables
     */
    public Text pointsText,
    positivePickUpsText,
    negativePickUpsText,
    timePickUpsText,
    speedPickUpsText,
    resetPickUpsText;

    /*
     * PRIVATE Class Variables
     */
    private int points,
   positivePickUps,
   negativePickUps,
   timePickUps,
   speedPickUps,
   resetPickUps;


    /*
     * UNITY Methods
     */

    private void Start()
    {
        points = GameStats.Points;
        positivePickUps = GameStats.PositivePickUps;
        negativePickUps = GameStats.NegativePickUps;
        timePickUps = GameStats.TimePickUps;
        speedPickUps = GameStats.SpeedPickUps;
        resetPickUps = GameStats.ResetPickUps;

        pointsText.text = points.ToString();
        positivePickUpsText.text = positivePickUps.ToString();
        negativePickUpsText.text = negativePickUps.ToString();
        timePickUpsText.text = timePickUps.ToString();
        speedPickUpsText.text = speedPickUps.ToString();
        resetPickUpsText.text = resetPickUps.ToString();
    }


    /*
     * PRIVATE Class Methods
     */

    /*
     * PUBLIC Class Methods
     */
}
