using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    // ���� ����
    // https://www.youtube.com/watch?v=P-UscoFwaE4

    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;

    void Start()
    {
        // �Ÿ����� ��Ȱ��ȭ
        distanceJoint.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // ���콺 ������ ��
        {
            // �� ���� ��ġ
            Vector3 linePos = new Vector3(transform.position.x + 3f, 4f, 0f);
            //Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ġ

            // �� ���۰� �� ��ġ ����
            lineRenderer.SetPosition(0, linePos);
            lineRenderer.SetPosition(1, transform.position);

            // Distance Joint 2D : Rigidbody 2D ���� ��Ģ�� �����ϴ� �� ���� ���� ������Ʈ�� �����ϰ� ������ ������ �����ϴ� 2D ����Ʈ
            distanceJoint.connectedAnchor = linePos;

            // �Ÿ� ����, �� Ȱ��ȭ
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0)) // ���콺 ���� ��
        {
            // �Ÿ� ����, �� ��Ȱ��ȭ
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
        }

        // �Ÿ� ���� Ȱ��ȭ ���̶�� �÷��̾� ��ġ ��� ������Ʈ 
        if (distanceJoint.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}
