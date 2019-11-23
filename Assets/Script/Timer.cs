using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public decimal Time;
    private TimerText;

   void Awake()
    {
        TimerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Time = System.Math.Round((decimal)Time);
        TimerText.text = Time.ToString();
    }

    private class TimerText
    {
        internal static string text;
    }
}
