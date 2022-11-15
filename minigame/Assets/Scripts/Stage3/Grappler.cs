using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject UIManager;

    public GameObject startPnl;
    public GameObject gameoverPnl;
    
    float time;
    int score;
    public Text scoreTxt;
    public Text bscoreTxt;

    bool isGaming;
    Vector3 bestDist;

    void Start()
    {
        isGaming = false;
        // 거리유지 비활성화
        distanceJoint.enabled = false;
        rigidbody2d.bodyType = RigidbodyType2D.Static;

        bestDist = transform.position;
    }

    void Update()
    {
        if (isGaming)
        {
            time += Time.deltaTime;
            score = (int)time * 10;
            scoreTxt.text = score + "point";

            if (bestDist.x < transform.position.x) // 멀리 간 거리 갱신
                bestDist.x = transform.position.x;

            if (bestDist.x > transform.position.x)
            {
                distanceJoint.enabled = false;
                lineRenderer.enabled = false;
            }


            Vector3 temp = transform.position;
            temp.x += 3 * Time.deltaTime;
            temp.y += 0.3f * Time.deltaTime;
            transform.position = temp;

            if (Input.GetKeyDown(KeyCode.Mouse0) && !UIManager.GetComponent<UIManager>().isPause) // 마우스 눌렀을 때
            {
                // 줄 생성 위치
                Vector3 linePos = new Vector3(transform.position.x + 3f, 4.5f, 0f);
                //Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치

                // 줄 시작과 끝 위치 지정
                lineRenderer.SetPosition(0, linePos);
                lineRenderer.SetPosition(1, transform.position);

                // Distance Joint 2D : Rigidbody 2D 물리 법칙이 제어하는 두 개의 게임 오브젝트를 연결하고 일정한 간격을 유지하는 2D 조인트
                distanceJoint.connectedAnchor = linePos;

                // 거리 유지, 줄 활성화
                distanceJoint.enabled = true;
                lineRenderer.enabled = true;

                //transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, transform.position.z);
                
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

            if (transform.position.y <= -5) // 절대 좌표
            {
                GameState(false);           // 게임 오버
            }
        }
    }

    public void GameState(bool val) // true이면 GameStart, false이면 GameOver
    {
        isGaming = val;
        startPnl.SetActive(!val);

        distanceJoint.enabled = false;
        lineRenderer.enabled = false;

        if (val) //GameStart
        {
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else     //GameOver
        {
            gameoverPnl.SetActive(true);
            rigidbody2d.bodyType = RigidbodyType2D.Static;
            transform.position = new Vector3(-0.31f, 1.23f, -1f);
            bestDist = transform.position;

            if (score > GameManager.Instance.bestScore[3])
                GameManager.Instance.bestScore[3] = score;
            bscoreTxt.text = "best score: " + GameManager.Instance.bestScore[3].ToString() + "\nnow score: " + score;

            time = 0;
            score = 0;
            scoreTxt.text = "0point";
        }
    }
}
