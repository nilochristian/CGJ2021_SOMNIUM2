using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Text scoreText;
    public Text minuteText;
    public static int minutesLeft = 120;
    public static int lightPoints = 7;
    public bool takingAway = false;

    private void Start()
    {
        int minute = minutesLeft / 60;
        int seconds = minutesLeft % 60;
        string msg = seconds < 10 ?
            minute + "h0" + seconds + " para às 3h00AM":
            minute + "h" + seconds + " para às 3h00AM";
        minuteText.text = msg;
    }

    void Update()
    {
        showMinuteTime();
        showMessageScore();
    }

    private void showMessageScore()
    {
        string msg = lightPoints == 0 ? 
            "Hora de Ir Dormir!":
            "Luzes remanescentes: "+ lightPoints.ToString() + "/7";
        scoreText.text = msg;
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        minutesLeft--;
        int minute = minutesLeft / 60;
        int seconds = minutesLeft % 60;
        minuteText.text = minute + "h" + seconds + " para às 3h00AM";
        takingAway = false;
    }

    private void showMinuteTime()
    {
        if(takingAway == false && minutesLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

}
