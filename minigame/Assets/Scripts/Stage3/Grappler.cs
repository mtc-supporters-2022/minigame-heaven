using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    // ���� ����
    // https://www.youtube.com/watch?v=P-UscoFwaE4
    
    [Header("Component")]
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;
    public Rigidbody2D rigidbody2d;

    [Header("GameObject")]
    public GameObject blackPnl;
    public GameObject startbtn;

    bool isGaming;

    void Start()
    {
        isGaming = false;
        // �Ÿ����� ��Ȱ��ȭ
        distanceJoint.enabled = false;
        rigidbody2d.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (isGaming)
        {
            if (transform.position.y <= -5) // ���� ��ǥ
            {
                GameState(false);
            }

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
    /*
    public void GameStart()
    {
        isGaming = true;
        blackPnl.SetActive(false);
        startbtn.SetActive(false);

        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
    }

    public void GameOver()
    {
        isGaming = false;
        blackPnl.SetActive(true);
        startbtn.SetActive(true);

        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
        rigidbody2d.bodyType = RigidbodyType2D.Static;

        transform.position = new Vector3(-1.2243f, 0.6691437f, -0.22938f);
    }*/

    public void GameState(bool val) // true�̸� GameStart, false�̸� GameOver
    {
        isGaming = val;
        blackPnl.SetActive(!val);
        startbtn.SetActive(!val);

        distanceJoint.enabled = false;
        lineRenderer.enabled = false;

        if (val)
        {
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rigidbody2d.bodyType = RigidbodyType2D.Static;
            transform.position = new Vector3(-1.2243f, 0.6691437f, -0.22938f);
        }
    }
}
