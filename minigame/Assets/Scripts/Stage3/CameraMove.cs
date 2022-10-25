using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 20.0f;
    public GameObject player;
    private void Update()
    {
        // targetPos ��� player.transform.position�� ����ߴ��� �÷��̾��� z�� ��ġ���� ���󰡼� �����Ű�� �Ⱥ��̴� ������ ������
        Vector3 targetPos = new Vector3(player.transform.position.x + 0.7f, player.transform.position.y, transform.position.z);

        // �������� Lerp
        // �ٵ� ���� �����Ÿ��� => rigidbody ���� ����
        transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * cameraSpeed);
        // transform.position ����, this.transform.position ����
    }
}
