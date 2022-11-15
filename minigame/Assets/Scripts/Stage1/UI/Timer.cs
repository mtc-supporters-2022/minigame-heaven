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
    public GameObject prince;
    public GameObject skeleton;
    public GameObject soundEffect;
    private float time;
    private int score;
    private int score2;
    private int score3;

    private int multi;
    public int princeMulti;

    private int ranMax;
    private int ranMin;
    private int r;

    private int skelranMax;
    private int skelranMin;
    private int skelr;

    private void Start()
    {
        multi = 0;
        ranMax = 15;
        ranMin = 4;
        skelranMax = 5;
        skelranMin = 3;
        skelr = UnityEngine.Random.Range(skelranMin, skelranMax);
        skelr *= 10;
        score3 = 0;
        r = UnityEngine.Random.Range(ranMin, ranMax);
        r *= 10;
        score3 += r;
        Debug.Log(r/10);

    }

    private void Update()
    {
        if (!isPause)
        {
            time += Time.deltaTime;

            if (time > 1)
            {
                score = score + 10;
                score2 = score2 + 10;
                time = 0;
            }

            if (score2 == (princeMulti + (multi * princeMulti)))
            {
                if (Player.Inst.getCount() < 3)
                {
                    prince.SetActive(true);
                    prince.transform.parent.transform.position = Vector3.zero;
                    ranMax--;
                    if (ranMax == 7)
                    {
                        ranMax = 7;
                    }
                }
                multi++;
            }

            if (score2 == score3 - skelr)
            {
                //½ºÄÌ·¹Åæ ON
                soundEffect.SetActive(true);
                skelr = UnityEngine.Random.Range(skelranMin, skelranMax);
                skelr *= 10;
                StartCoroutine(AudioPlay());
            }

            if (score2 == score3)
            {
                //½ºÄÌ·¹Åæ ON
                
                skeleton.SetActive(true);
                score3 += 20; // ½ºÄÌ·¹Åæ ¾Ö´Ï¸ÞÀÌ¼Ç ³ª¿À´Â ½Ã°£ 3ÃÊ
                r = UnityEngine.Random.Range(ranMin, ranMax);
                r *= 10;
                score3 += r;

                if(ranMax==10)
                Debug.Log(r/10);


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

    IEnumerator AudioPlay()
    {
        yield return new WaitForSeconds(2f);
        soundEffect.SetActive(false);
    }

}
