using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeLimit : MonoBehaviour
{
    [Range(-1, 59)] public int minutes;
    [Range(-1, 59)] public int hours;
    [Range(-1, 59)] public int seconds;

    [Range(0.1f, 100f)]
    public float threshold;
    [Range(0.1f, 2f)] public float timeIncrement;
    public bool active, hourCount;

    public UnityEvent onEnd;

    public TextMeshProUGUI hourDisplay, minuteDisplay, secondDisplay;

    private float time;

    private bool timeEnd, exEvent;

    private float redFocus = 1f;

    private Color mainColor = new Color(1f, 1f, 1f); 

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += timeIncrement;
        }

        if (time > threshold && !timeEnd)
        {
            time = 0;

            seconds--;
        }

        if (seconds == -1)
        {
            if (minutes > -1 && !hourCount)
            {
                minutes--;

                if (minutes == -1)
                {
                    timeEnd = true;
                }
            }

            if (hourCount)
            {
                minutes--;

                if (minutes == -1 && hourCount && hours > 0)
                {
                    hours--;
                    minutes = 59;
                }
            }

            seconds = 59;
        }

        if (timeEnd)
        {
            seconds = 0;
            minutes = 0;

            if (!exEvent)
            {
                onEnd.Invoke();
                exEvent = true;
            }
        }

        SetText();
    }

    void SetText()
    {
        Color endColor = new Color(1f, redFocus, redFocus);

        float ospeed = 1f;

        float t = Mathf.PingPong(Time.time * ospeed, 1f);

        Color color = Color.Lerp(mainColor, endColor, t);

        if (hourCount)
        {
            hourDisplay.gameObject.SetActive(true);
            hourDisplay.text = $"{hours}:";

            if (hours >= 0 && hours < 10)
            {
                hourDisplay.text = $"0{hours}:";
            }
        }
        else
        {
            hourDisplay.gameObject.SetActive(false);
            hours = 0;
        }

        minuteDisplay.text = $"{minutes}:";

        if (minutes >= 0 && minutes < 10)
        {
            minuteDisplay.text = $"0{minutes}:";
        }

        secondDisplay.text = seconds.ToString();
        if (seconds >= 0 && seconds < 10)
        {
            secondDisplay.text = $"0{seconds}";
        }

        if (minutes <= 1)
        {
            redFocus = 0.85f;
            ospeed = 2.45f;

            hourDisplay.color = color;
            minuteDisplay.color = color;
            secondDisplay.color = color;
        }

        if (minutes == 0)
        {
            redFocus = 0.5f;
            ospeed = 6.45f;

            if (seconds < 31)
            {
                redFocus = 0.15f;
                ospeed = 12.75f;
            }
        }
    }

    void SetSeconds(int value)
    {
        seconds = value;
    }

    void SetMinutes(int value)
    {
        minutes = value;
    }

    void SetHours(int value)
    {
        hours = value;
    }

    bool SetActive(bool result)
    {
        return result;
    }
}
