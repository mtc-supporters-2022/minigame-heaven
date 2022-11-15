using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skeleton : MonoBehaviour
{
    Sequence sequence;

    [SerializeField] float duration;
    [SerializeField] float strength;
    [SerializeField] int vibrato;
    [SerializeField] int randomness;

    // Start is called before the first frame update
    void Start()
    {
        sequence = DOTween.Sequence()
            .SetAutoKill(false) //Ãß°¡
            .OnStart(() =>
            {
                transform.position = Vector3.zero;
            })
            .Append(transform.DOShakePosition(duration,2))
            .AppendInterval(0.2f)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
                Touch.Inst.setDoClick(true);
                Touch.Inst.startRecovery();
            });
    }

    private void OnEnable()
    {
        Touch.Inst.setDoClick(false);
        sequence.Restart();
    }


}
