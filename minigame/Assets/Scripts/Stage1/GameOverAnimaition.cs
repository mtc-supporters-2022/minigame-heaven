using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverAnimaition : MonoBehaviour
{
    Sequence sequence;

    [SerializeField] float duration;
    [SerializeField] GameObject skel1;
    [SerializeField] GameObject touch;
    [SerializeField] Camera mcamera;

    // Start is called before the first frame update
    void Start()
    {
        sequence = DOTween.Sequence()
            .SetAutoKill(false) //Ãß°¡
            .OnStart(() =>
            {
                Timer.Inst.setPause(true);
                mcamera.GetComponent<AudioSource>().mute = true;
                skel1.SetActive(false);
                transform.position = Vector3.zero;
                transform.localScale = Vector3.zero;
                touch.SetActive(false);
            })
            .Append(transform.DOShakePosition(duration, 2))
            .Join(transform.DOScale(100, 2f))
            .Append(transform.GetComponent<SpriteRenderer>().DOFade(0,0.5f))
            .OnComplete(() =>
            {
                Player.Inst.GameOver();

            });
    }

    private void OnEnable()
    {
        sequence.Restart();
    }
}
