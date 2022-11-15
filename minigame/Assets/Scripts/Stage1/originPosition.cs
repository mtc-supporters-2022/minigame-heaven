using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class originPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 originPos;
    public Vector3 nextPos;

    private void Start()
    {
        originPos = transform.position; //시작하자마자 현재 위치 받아옴
        nextPos= transform.position + (Vector3.left * 0.5f); //바로 왼쪽 위치 받아옴
    }

    public void nextPosUpdate()
    {
        originPos = transform.position;
        nextPos = transform.position + (Vector3.left * 0.5f);
    }
}
