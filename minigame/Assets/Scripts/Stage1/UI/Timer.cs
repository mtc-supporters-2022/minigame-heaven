using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    private bool isPause = true;
    public Text text;
    private float time;

    private void Update()
    {
        if (!isPause)
        {
            time += Time.deltaTime;
            text.text = string.Format("{0:N2}", time);
        }
    }

    public void setPause(bool pauseBool)
    {
        isPause = pauseBool;
    }

}
