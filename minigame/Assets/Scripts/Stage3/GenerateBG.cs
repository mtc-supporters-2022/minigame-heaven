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

    int c_num = 0; // 가장 왼쪽에 있는 친구들
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
        배경 좌표1, 배경 좌표2, 배경 좌표3 존재
        가장 왼쪽에 있는 애 식별, 계속 +1 해주고 3으로 나눈 나머지 사용
        플레이어 좌표가 가운데 배경 좌표+a일 때, 가장 왼쪽 배경을 가장 오른쪽으로 이동
        */

        if (Grappler.GetComponent<Grappler>().gameStart)
        {
            // 천장 판별 후 이동
            if (player.transform.position.x > ceiling[(c_num+2)%3].transform.position.x)
            {
                ceiling[c_num].transform.position = new Vector3(ceiling[(c_num + 2) % 3].transform.position.x + 7.9f, ceiling[c_num].transform.position.y, ceiling[c_num].transform.position.z);
                c_num = (c_num + 1) % 3; // c_num 갱신
            }

            // 벽 판별 후 이동
            if (player.transform.position.x > wall[(w_num + 3) % 4].transform.position.x)
            {
                wall[w_num].transform.position = new Vector3(wall[(w_num + 3) % 4].transform.position.x + 7.92f, wall[w_num].transform.position.y, wall[w_num].transform.position.z);
                w_num = (w_num + 1) % 4; // w_num 갱신
            }

            // 용암 판별 후 이동
            if (player.transform.position.x > lava[(l_num + 2) % 3].transform.position.x)
            {
                lava[l_num].transform.position = new Vector3(lava[(l_num + 2) % 3].transform.position.x + 7.8f, lava[l_num].transform.position.y, lava[l_num].transform.position.z);
                l_num = (l_num + 1) % 3; // l_num 갱신
            }
        }
        else
        {
            c_num = 0;
            w_num = 0;
            l_num = 0;

            // 원위치
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
