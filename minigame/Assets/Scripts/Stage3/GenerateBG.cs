using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBG : MonoBehaviour
{
    public GameObject player;
    public GameObject[] ceiling;
    public GameObject[] wall;
    public GameObject[] lava;

    int ceiling_num = 0;
    int wall_num = 0;
    int lava_num = 0;

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
        if (player.transform.position.x > ceiling[0].transform.position.x)  // -11.43 / -3.6 / 4.3
            Debug.Log(player.transform.position);

        // �� �Ǻ� �� �̵�

        // ��� �Ǻ� �� �̵�

    }
}
