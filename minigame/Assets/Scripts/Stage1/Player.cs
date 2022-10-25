using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State { Stand, Idle, Run, Hit, Recovery }
    public static Player Inst { get; private set; }

    [SerializeField] GameObject touchScreen;

    Animator anim;

    void Awake()
    {
        Inst = this;
        anim = GetComponent<Animator>();
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
        touchScreen.SetActive(false);
        ChangeAnim(State.Hit);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        ChangeAnim(State.Recovery);
        Invoke("ActiveOn", 0.5f);
    }

    public void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }

    void ActiveOn()
    {
        touchScreen.SetActive(true);
    }

    //애니메이션
    //사운드

}
