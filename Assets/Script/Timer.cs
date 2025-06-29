using NUnit.Framework;
using TMPro;
using UnityEngine;
using static GameMenager;

public class Timer : MonoBehaviour
{
    public delegate void TimeHasBeenExceeded();
    public static TimeHasBeenExceeded timehasbeenexceeded;


    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private GameObject TheTimerObject;
    public float timerinSeconds;
    bool TimerisStart;

    private void Start()
    {
        TimerisStart = false;
        GameMenager.TriggerTimer += StartTimerExist;
    }
    void Update()
    {
        TimerisStarted();



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

         
            TheTimerObject .SetActive(true);
            timerinSeconds -= Time.deltaTime;
            DisplayTime(timerinSeconds);
        }
    
    }
    void DisplayTime(float timeToDisplay)
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
