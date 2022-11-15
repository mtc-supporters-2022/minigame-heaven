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
        배경 좌표1, 배경 좌표2, 배경 좌표3 존재
        가장 왼쪽에 있는 애 식별, 계속 +1 해주고 3으로 나눈 나머지 사용
        플레이어 좌표가 가운데 배경 좌표+a일 때, 가장 왼쪽 배경을 가장 오른쪽으로 이동
        */

        // 천장 판별 후 이동
        if (player.transform.position.x > ceiling[0].transform.position.x)  // -11.43 / -3.6 / 4.3
            Debug.Log(player.transform.position);

        // 벽 판별 후 이동

        // 용암 판별 후 이동

    }
}
