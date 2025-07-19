using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameMenager;

public class Timer : MonoBehaviour
{
    public delegate void TimeHasBeenExceeded();
    public static TimeHasBeenExceeded timehasbeenexceeded;


    [SerializeField] private TextMeshProUGUI TimeText;

    [SerializeField] private Image ImageTimer;

    [SerializeField] private GameObject TheTimerObject;




    private float TimerReal;
    private float TimerinProcent;
    private float Timerset;


    public float timerinSeconds;
    private float timeaftertimedeltatime;
    
    bool TimerisStart;

    private void Start()
    {
        Timerset = timerinSeconds;
        TimerisStart = false;
        GameMenager.TriggerTimer += StartTimerExist;
    }
    void Update()
    {
        TimerisStarted();

        ImageTimer.fillAmount =  TimerReal / Timerset;

    }
    private void StartTimerExist()
    {
        TimerisStart = true;
    }

    private void TimerisStarted()
    {
        if (TimerisStart)
        {
            
            timerinSeconds -= Time.deltaTime;


             TimerReal = timerinSeconds;


            TheTimerObject .SetActive(true);
            
            DisplayTime(timerinSeconds);
        }
    
    }
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.CeilToInt(timeToDisplay);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeToDisplay < 0)
        {
            if(timehasbeenexceeded != null)
            {
                timehasbeenexceeded();
                TheTimerObject.SetActive(false);
            }
            else { Debug.LogWarning("Delegate is null"); }
           
        }
    }

}
