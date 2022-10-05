using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float speed = 3f; //1~20 ���� �ӵ� ����

    [SerializeField] float posValue; //�����̴� ��ġ �ִ�ġ

    Vector2 startPos; //������
    float newPos; //������
    bool isRun; //ȭ���� ��ġ�ߴ°�


    private void Start()
    {
        startPos = transform.position;
        isRun = false;
    }

    private void Update()
    {
        if (isRun) //ȭ�� ��ġ���� ��
        {
            newPos = Mathf.Repeat(Time.time * speed, posValue); // 0 < �ð� * �ӵ� �� �� < posValue;
            transform.position = startPos + Vector2.left * newPos; //ó�� ��ġ * �������� -1 �̵� * ���ο� ��ġ �� 
        }

    }

    public void IsRun(bool run)
    {
        isRun = run;
    }
}
