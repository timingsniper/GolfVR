using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameCore_Data;

public class TimeSpeed : MonoBehaviour
{
    Text info;
    Rigidbody rb;
    float tim=0;
    int min=0, v;
    bool updated = false;
    void Start()
    {
        rb = pl.GetComponent<Rigidbody>();
        info = tx.GetComponent<Text>();
        tx.SetActive(true);
    }
    void Update()
    {
        int s = (int)(tim * 10);
        if (finished)
        {
            if (!updated)
            {
                info.text = $"<color=red>{min / 10}{min % 10}:{s / 100}{s / 10 % 10}.{s % 10}   !</color>";
                updated = true;
            }
            return;
        }
        tim += Time.deltaTime;
        if (tim >= 60) { tim -= 60; ++min; }
        int tv = v;
        v = (int)rb.velocity.magnitude;
        s = (int)(tim * 10);
        info.text = $"{min / 10}{min % 10}:{s / 100}{s / 10 % 10}.{s % 10}      {v / 100}.{v / 10 % 10}{v % 10}m/s";
        au1.GetComponent<AudioSource>().volume = v / 800.0f;
        if (Mathf.Abs(tv - v) > 40)
        {
            au2.GetComponent<AudioSource>().volume = (Mathf.Abs(tv - v) - 40) / 800.0f;
            au2.GetComponent<AudioSource>().Play();
        }
    }
}
