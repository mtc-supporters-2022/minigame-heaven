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

    Animator[] anim;
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

    //장애물 터치 트리거 충돌

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Plus();
        //Plus();
        /*        touchScreen.SetActive(false);
                ChangeAnim(State.Hit);
                Invoke("ActiveOn", 0.7f);*/
    }

    /*    void OnTriggerExit2D(Collider2D collision)
        {

            ChangeAnim(State.Recovery);
            Invoke("ActiveOn", 0.5f);
        }*/

    public void ChangeAnim(State state)
    {
        for (int i = 0; i < princess.Length; i++) { anim[i].SetInteger("State", (int)state); }
    }
    /*
        void ActiveOn()
        {
            ChangeAnim(State.Recovery);
            touchScreen.SetActive(true);
        }*/

    public void Plus()
    {

        if (princessCount == 1 || princessCount == 2)
        {

            Sequence sequence = DOTween.Sequence();
            sequence.Append(princess[princessCount].transform.DOMove(princess[princessCount].GetComponent<originPosition>().nextPos, 0.2f))
                .OnComplete(() =>
                {
                    if (princessCount == 1)
                    {
                        princess[2].GetComponent<originPosition>().nextPosUpdate();
                        princessCount++;

                    }
                });
        }
    }

    public void Minus()
    {
        if (princessCount == 1 || princessCount == 2)
        {
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(princess[princessCount].transform.DOMove(princess[princessCount].GetComponent<originPosition>().originPos, 0.2f))
                .OnComplete(() =>
                {
                    if (princessCount == 2)
                        princessCount--;
                });


        }
    }

    //애니메이션
    //사운드

}
