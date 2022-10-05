using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float speed = 3f; //1~20 사이 속도 조절

    [SerializeField] float posValue; //움직이는 위치 최대치

    Vector2 startPos; //시작점
    float newPos; //증가값
    bool isRun; //화면을 터치했는가


    private void Start()
    {
        startPos = transform.position;
        isRun = false;
    }

    private void Update()
    {
        if (isRun) //화면 터치했을 때
        {
            newPos = Mathf.Repeat(Time.time * speed, posValue); // 0 < 시간 * 속도 한 값 < posValue;
            transform.position = startPos + Vector2.left * newPos; //처음 위치 * 왼쪽으로 -1 이동 * 새로운 위치 값 
        }

    }

    public void IsRun(bool run)
    {
        isRun = run;
    }
}
