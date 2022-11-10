using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ScoreDoTween : MonoBehaviour
{
    Sequence sequence;
    RectTransform rect;

    [SerializeField] Vector3 originPosition;
    // Start is called before the first frame update

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    void Start()
    {
        sequence = DOTween.Sequence()
            .SetAutoKill(false) //Ãß°¡
            .OnStart(() =>
            {
                //transform.position = originPosition;
                //transform.GetComponent<Text>().color = new Color32(255,239,0,255);
            })
            .Append(rect.DOAnchorPosY(-90, 0.7f))
            .Join(transform.GetComponent<Text>().DOFade(0,0.7f))
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }

    private void OnEnable()
    {
        sequence.Restart();
    }
}
