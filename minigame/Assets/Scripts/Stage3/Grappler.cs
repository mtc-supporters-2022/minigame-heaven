using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    // 참고 영상
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
        // 거리유지 비활성화
        distanceJoint.enabled = false;
        rigidbody2d.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (isGaming)
        {
            if (transform.position.y <= -5) // 절대 좌표
            {
                GameState(false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0)) // 마우스 눌렀을 때
            {
                // 줄 생성 위치
                Vector3 linePos = new Vector3(transform.position.x + 3f, 4f, 0f);
                //Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치

                // 줄 시작과 끝 위치 지정
                lineRenderer.SetPosition(0, linePos);
                lineRenderer.SetPosition(1, transform.position);

                // Distance Joint 2D : Rigidbody 2D 물리 법칙이 제어하는 두 개의 게임 오브젝트를 연결하고 일정한 간격을 유지하는 2D 조인트
                distanceJoint.connectedAnchor = linePos;

                // 거리 유지, 줄 활성화
                distanceJoint.enabled = true;
                lineRenderer.enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0)) // 마우스 뗐을 때
            {
                // 거리 유지, 줄 비활성화
                distanceJoint.enabled = false;
                lineRenderer.enabled = false;
            }

            // 거리 유지 활성화 중이라면 플레이어 위치 계속 업데이트 
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

    public void GameState(bool val) // true이면 GameStart, false이면 GameOver
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
