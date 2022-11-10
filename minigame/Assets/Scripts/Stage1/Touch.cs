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

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
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
}
