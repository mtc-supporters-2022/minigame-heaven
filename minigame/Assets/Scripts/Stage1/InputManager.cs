using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject backGround;
    public GameObject animator;
    public Prince prin;
    public Animator[] prince;

    bool isFade;

    void Awake()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) //마우스 누르고 있을 시
        {
            StartCoroutine(MoveOrStop(true));

        }
        else //떼면
        {
            StartCoroutine(MoveOrStop(false));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            prin.Plus();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            prin.Minus();
        }
    }

    IEnumerator MoveOrStop(bool isStop)
    {
        StartCoroutine(DoFade(isStop));
        backGround.GetComponent<Scrolling>().IsRun(isStop);
        
        foreach (Animator animators in prince)
        {
            animators.SetBool("isRunning", isStop);
        }

        yield return null;
    }

    public IEnumerator DoFade(bool isFade)
    {
        if (isFade)
            gameObject.GetComponent<Image>().DOFade(0.0f, 0.3f);
        else
            gameObject.GetComponent<Image>().DOFade(0.5f, 0.3f);

        yield return null;

    }
}



