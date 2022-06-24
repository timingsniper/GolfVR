using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameCore_Data;

public class TimeSpeed : MonoBehaviour
{
    Vector3 temp;
    Text info;
    Rigidbody rb;
    float tim = 0, spd = 0.7f, rec = 1;
    Color col = Color.blue;
    int min = 0, v;
    bool updated = false;
    void Start()
    {
        temp = pl.transform.position;
        rb = pl.GetComponent<Rigidbody>();
        info = tx.GetComponent<Text>();
        tx.SetActive(true);
    }
    void Update()
    {
        if(pl.transform.position.y < -50)
        {
            pl.transform.position = temp;
            pl.transform.rotation = new Quaternion(0, 0, 0, 1);
            rb.velocity = Vector3.zero;
            v = 0;
            return;
        }
        int s = (int)(tim * 10);
        if (finished)
        {
            if (!updated)
            {
                if (min == 0 && s < 400) { col = Color.green; spd = 1.2f; }
                if (min == 0 && s < 300) { col = Color.cyan; spd = 1.7f; }
                if (min == 0 && s < 270) { col = Color.red; spd = 2.2f; }
                info.text = $"{min / 10}{min % 10}:{s / 100}{s / 10 % 10}.{s % 10}   !";
                updated = true;
            }
            rec += spd * Time.deltaTime; if (rec >= 2) rec -= 2;
            col.a = (rec <= 1 ? rec : 2 - rec);
            info.color = col;
            return;
        }
        tim += Time.deltaTime;
        if (tim >= 60) { tim -= 60; ++min; }
        int tv = v;
        v = (int)rb.velocity.magnitude;
        s = (int)(tim * 10);
        info.text = $"{min / 10}{min % 10}:{s / 100}{s / 10 % 10}.{s % 10}      {v / 100}.{v / 10 % 10}{v % 10}m/s";
        au1.GetComponent<AudioSource>().volume = v / 700.0f;
        if (Mathf.Abs(tv - v) > 40)
        {
            au2.GetComponent<AudioSource>().volume = (Mathf.Abs(tv - v) - 40) / 800.0f;
            au2.GetComponent<AudioSource>().Play();
        }
    }
}
