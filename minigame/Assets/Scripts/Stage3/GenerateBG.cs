using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBG : MonoBehaviour
{
    public GameObject player;
    public GameObject[] ceiling;
    public GameObject[] wall;
    public GameObject[] lava;

    void Start()
    {
        Debug.Log(player.transform.position);
    }


    void Update()
    {
        /*
        ��� ��ǥ1, ��� ��ǥ2, ��� ��ǥ3 ����
        ���� ���ʿ� �ִ� �� �ĺ�, ��� +1 ���ְ� 3���� ���� ������ ���
        �÷��̾� ��ǥ�� ��� ��� ��ǥ+a�� ��, ���� ���� ����� ���� ���������� �̵�
        */

        // õ�� �Ǻ� �� �̵�
        if (player.transform.position.x > ceiling[0].transform.position.x)
            Debug.Log(player.transform.position);
        // �� �Ǻ� �� �̵�

        // ��� �Ǻ� �� �̵�

    }
}
