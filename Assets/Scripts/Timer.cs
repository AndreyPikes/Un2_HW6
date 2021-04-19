using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private float maxTime = 10f;    
    [SerializeField] Image backround;
    private float currentTime = 0f;
    private float timeCounter;
    public delegate void TimerOver();
    public event TimerOver timeExpired;
    public static Timer timerInstance;

    private void Awake() 
    {
        if (Timer.timerInstance != null) 
        {
            Destroy(this); 
            return;
        }
        Timer.timerInstance = this;
    }
    void Start()
    {
        NewGameTimer();
    }
    void Update()
    {
        TimeCounter(GameManager.win);
    }

    public void NewGameTimer()
    {
        currentTime = Time.time;
        timeCounter = maxTime;        
        backround.fillAmount = 0;
    }

    private void TimeCounter(bool win)
    {
        if (!win)
        {
            if (timeCounter > 0)
            {
                timeCounter = Mathf.Round(maxTime - Time.time + currentTime);
                timer.text = timeCounter.ToString();
                backround.fillAmount += 1.05f / maxTime * Time.deltaTime;
            }
            else
            {
                timeExpired();
            }
        }
    }
}
