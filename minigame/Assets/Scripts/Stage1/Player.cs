using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public enum State { Stand, Idle, Run, Hit, Recovery }
    public static Player Inst { get; private set; }

    [SerializeField] GameObject touchScreen;
    [SerializeField] GameObject[] princess;
    [SerializeField] GameObject prince;

    Animator[] anim;
    int princessNum;
    int princessCount;

    void Awake()
    {
        Inst = this;
        anim = new Animator[3];
        for (int i = 0; i < princess.Length; i++) { anim[i] = princess[i].GetComponent<Animator>(); }

        princessCount = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Plus();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Minus();
        }

    }

    public void DoIdle()
    {
        ChangeAnim(State.Idle);
    }

    public void DoRun()
    {
        ChangeAnim(State.Run);
    }

    public void DoHit()
    {
        ChangeAnim(State.Hit);
    }

    public void DoRecovery()
    {
        ChangeAnim(State.Recovery);
    }

    //장애물 터치 트리거 충돌

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Plus();
        prince.SetActive(false);
    }

    public void ChangeAnim(State state)
    {
        for (int i = 0; i < princess.Length; i++) { anim[i].SetInteger("State", (int)state); }
    }

    public void Plus()
    {

        if (princessCount<3)
        {

            Sequence sequence = DOTween.Sequence();
            sequence.Append(princess[princessCount].transform.DOMove(princess[princessCount].GetComponent<originPosition>().nextPos, 0.2f))
                .OnComplete(() =>
                {
                    if (princessCount == 1)
                    {
                        princess[princessCount+1].GetComponent<originPosition>().nextPosUpdate();
                    }
                    princessCount++;
                });
        }
    }

    public void Minus()
    {
        if(princessCount==1)
            //게임 오버

        if (princessCount>0 && princessCount!=1)
        {
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(princess[princessCount-1].transform.DOMove(princess[princessCount-1].GetComponent<originPosition>().originPos, 0.2f))
                .OnComplete(() =>
                {
                    princessCount--;

                });
        }
    }

    public int getCount()
    {
        return princessCount;
    }

    //애니메이션
    //사운드

}
