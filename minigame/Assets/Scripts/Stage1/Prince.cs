using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Prince : MonoBehaviour
{

    public GameObject[] prince;
    int num;
    int moveCount;
    // Start is called before the first frame update
    void Start()
    {
        moveCount = 0;
        num = 0;
        foreach (GameObject obje in prince)
        {
            obje.SetActive(false);
        }
    }

    public void Plus()
    {
        prince[num].SetActive(true);
        if (moveCount < prince.Length)
        {
            if (moveCount == 1)
                prince[0].transform.DOMove(prince[0].transform.position + Vector3.right, 0.5f);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(gameObject.transform.DOMove(transform.position + Vector3.right, 0.5f))
                    .OnComplete(() =>
                    {


                        num++;
                        if (num >= prince.Length)
                            num = 1;

                    });
            moveCount++;
        }

    }

    public void Minus()
    {

        if (moveCount > 0)
        {
            if (moveCount == 2)
                prince[0].transform.DOMove(prince[0].transform.position + Vector3.left, 0.5f);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(gameObject.transform.DOMove(transform.position + Vector3.left, 0.5f))
                    .OnComplete(() =>
                    {
                        prince[num].SetActive(false);

                        num--;
                        if (num < 0)
                            num = 0;

                    });
            moveCount--;
        }




    }

}
