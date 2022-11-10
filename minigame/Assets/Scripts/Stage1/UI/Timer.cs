using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static Timer Inst { get; private set; }
    void Awake() => Inst = this;

    private bool isPause = true;
    public Text text;
    public GameObject bonus;
    private float time;
    private int score;

    private void Update()
    {
        if (!isPause)
        {
            time += Time.deltaTime;

            if (time > 1)
            {
                score = score + 10;
                time = 0;
            }

            //text.text = string.Format("{0:N2}", time);
            text.text = score.ToString();
        }
    }

    public void Score(int score)
    {
        this.score += score;
        bonus.SetActive(true);
    }

    public void setPause(bool pauseBool)
    {
        isPause = pauseBool;
    }

}
