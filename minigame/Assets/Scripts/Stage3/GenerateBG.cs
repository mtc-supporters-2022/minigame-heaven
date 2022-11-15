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
    Vector3[] startPos = new Vector3[10];

    void Start()
    {
        startPos[0] = ceiling[0].transform.position;
        startPos[1] = ceiling[1].transform.position;
        startPos[2] = ceiling[2].transform.position;

        startPos[3] = wall[0].transform.position;
        startPos[4] = wall[1].transform.position;
        startPos[5] = wall[2].transform.position;
        startPos[6] = wall[3].transform.position;

        startPos[7] = lava[0].transform.position;
        startPos[8] = lava[1].transform.position;
        startPos[9] = lava[2].transform.position;
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
            if (player.transform.position.x > wall[(w_num + 3) % 4].transform.position.x)
            {
                wall[w_num].transform.position = new Vector3(wall[(w_num + 3) % 4].transform.position.x + 7.92f, wall[w_num].transform.position.y, wall[w_num].transform.position.z);
                w_num = (w_num + 1) % 4; // w_num ����
            }

            // ��� �Ǻ� �� �̵�
            if (player.transform.position.x > lava[(l_num + 2) % 3].transform.position.x)
            {
                lava[l_num].transform.position = new Vector3(lava[(l_num + 2) % 3].transform.position.x + 7.8f, lava[l_num].transform.position.y, lava[l_num].transform.position.z);
                l_num = (l_num + 1) % 3; // l_num ����
            }
        }
        else
        {
            c_num = 0;
            w_num = 0;
            l_num = 0;

            // ����ġ
            ceiling[0].transform.position = startPos[0];
            ceiling[1].transform.position = startPos[1];
            ceiling[2].transform.position = startPos[2];

            wall[0].transform.position = startPos[3];
            wall[1].transform.position = startPos[4];
            wall[2].transform.position = startPos[5];
            wall[3].transform.position = startPos[6];

            lava[0].transform.position = startPos[7];
            lava[1].transform.position = startPos[8];
            lava[2].transform.position = startPos[9];
        }

    }
}
