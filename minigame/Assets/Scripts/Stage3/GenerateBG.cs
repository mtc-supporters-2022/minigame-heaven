using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBG : MonoBehaviour
{
    public GameObject Grappler;

    public GameObject player;
    public GameObject[] ceiling;
    public GameObject[] wall;
    public GameObject[] lava;

    int c_num = 0; // ���� ���ʿ� �ִ� ģ����
    int w_num = 0;
    int l_num = 0;
    public Vector3[] startPos;

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

        if (Grappler.GetComponent<Grappler>().gameStart)
        {
            // õ�� �Ǻ� �� �̵�
            if (player.transform.position.x > ceiling[(c_num+2)%3].transform.position.x)
            {
                ceiling[c_num].transform.position = new Vector3(ceiling[(c_num + 2) % 3].transform.position.x + 7.9f, ceiling[c_num].transform.position.y, ceiling[c_num].transform.position.z);
                c_num = (c_num + 1) % 3; // c_num ����
            }

            // �� �Ǻ� �� �̵�
            if (player.transform.position.x > wall[(w_num + 2) % 4].transform.position.x)
            {
                wall[w_num].transform.position = new Vector3(wall[(w_num + 2) % 4].transform.position.x + 7.92f, wall[w_num].transform.position.y, wall[w_num].transform.position.z);
                w_num = (w_num + 1) % 4; // w_num ����
            }

            // ��� �Ǻ� �� �̵�
            if (player.transform.position.x > lava[(l_num + 2) % 3].transform.position.x)
            {
                lava[l_num].transform.position = new Vector3(lava[(c_num + 2) % 3].transform.position.x + 7.8f, lava[l_num].transform.position.y, lava[l_num].transform.position.z);
                l_num = (l_num + 1) % 3; // l_num ����
            }
        }
        else
        {
            c_num = 0;
            w_num = 0;
            l_num = 0;

            // ����ġ
            startPos[0].x = ceiling[0].transform.position.x;
            startPos[1].x = ceiling[1].transform.position.x;
            startPos[2].x = ceiling[2].transform.position.x;

            startPos[3].x = wall[0].transform.position.x;
            startPos[4].x = wall[1].transform.position.x;
            startPos[5].x = wall[2].transform.position.x;
            startPos[6].x = wall[3].transform.position.x;

            startPos[7].x = lava[0].transform.position.x;
            startPos[8].x = lava[1].transform.position.x;
            startPos[9].x = lava[2].transform.position.x;
        }

    }
}
