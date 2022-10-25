using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 20.0f;
    public GameObject player;
    private void Update()
    {
        // targetPos 대신 player.transform.position을 사용했더니 플레이어의 z축 위치까지 따라가서 실행시키면 안보이는 오류가 났었음
        Vector3 targetPos = new Vector3(player.transform.position.x + 0.7f, player.transform.position.y, transform.position.z);

        // 선형보간 Lerp
        // 근데 왜케 덜덜거리지 => rigidbody 설정 변경
        transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * cameraSpeed);
        // transform.position ㄱㄴ, this.transform.position ㄱㄴ
    }
}
