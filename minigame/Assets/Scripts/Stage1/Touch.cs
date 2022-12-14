using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public static Touch Inst { get; private set; }
    void Awake() => Inst = this;
    bool isTrigger;
    float time;
    int coolTime;
    bool skeleton;
    bool doClick;
    public bool oneTime;
    public GameObject gameOverSkeleton;

    private void Start()
    {
        doClick = true;
        oneTime = false;
    }

    void Update()
    {
        if (doClick)
        {
            if (Input.GetMouseButton(0))
            {
                oneTime = false;
                time += Time.deltaTime;

                if (time > 1)
                {
                    coolTime += 1;
                    time = 0;
                }

                if (coolTime == 7)
                {
                    StartCoroutine(BonusScore(50));
                    coolTime = 0;
                }
                //달리는 사운드
                Player.Inst.DoRun();
                isTrigger = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                time = 0;
                coolTime = 0;
                Player.Inst.DoIdle();
                isTrigger = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {


                if (!oneTime)
                {
                    if (Player.Inst.getNum() <= 0)
                        gameOverSkeleton.SetActive(true);

                    setTrigger(false);
                    Player.Inst.DoHit();
                    Player.Inst.Minus();
                    oneTime = true;
                }


            }
            else if (Input.GetMouseButtonDown(0))
            {


                if (!oneTime)
                {

                    if (Player.Inst.getNum() <= 0)
                        gameOverSkeleton.SetActive(true);


                    setTrigger(false);
                    Player.Inst.DoHit();
                    Player.Inst.Minus();
                    oneTime = true;
                }

            }
        }

    }

    private void OnDisable()
    {
        isTrigger = false;
    }

    public bool GetTrigger()
    {
        return isTrigger;
    }

    IEnumerator BonusScore(int score)
    {
        yield return new WaitForSeconds(1.0f);
        Timer.Inst.Score(score);
    }

    IEnumerator DoRecovery()
    {
        yield return new WaitForSeconds(0f);
        Player.Inst.DoRecovery();

    }

    public void startRecovery()
    {
        StartCoroutine(DoRecovery());
    }

    public void setDoClick(bool doClick)
    {
        this.doClick = doClick;
    }

    public void setTrigger(bool isTrigger)
    {
        this.isTrigger = isTrigger;
    }

    public void setOne(bool isTrigger)
    {
        this.oneTime = isTrigger;
    }
}
