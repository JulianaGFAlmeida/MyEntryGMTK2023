using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBehaviour : MonoBehaviour
{
    [SerializeField]
    private float totalTime = 60f; 
    private float currentTime=0;
    private Text countdownText;
    private bool isTimerRunning = false;
    [SerializeField]
    private DemonTransformerManager dtm;
    private PlayerBehaviour pb;
    [SerializeField]
    private PlayerBehaviour otherPb;

    private void Start()
    {
        countdownText = GetComponent<Text>();
        pb = dtm.gameObject.GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        if (isTimerRunning) { UpdateTimer(); }
    }

    void UpdateTimer()
    {

        currentTime -= Time.deltaTime;

        // Display the time remaining in the UI text element
        countdownText.text = "Timer: "+currentTime.ToString("0");

        // Check if the countdown has reached zero
        if (currentTime <= 0)
        {
            currentTime = 0;
            isTimerRunning = false;
            countdownText.text = "";
            dtm.ResetAmountCollected();
            pb.BackToNormal();
            otherPb.SetAmITheKiller(true);
            // Perform any actions you need when the timer reaches zero
        }
    }
    public void StartTimer()
    {
        currentTime = totalTime;
        isTimerRunning = true;
        pb.DemonBuff();
        otherPb.SetAmITheKiller(false);
    }
}
