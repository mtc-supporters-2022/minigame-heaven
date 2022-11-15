using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // �Ÿ����� ��Ȱ��ȭ
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

            if (bestDist.x < transform.position.x) // �ָ� �� �Ÿ� ����
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

            if (Input.GetKeyDown(KeyCode.Mouse0) && !UIManager.GetComponent<UIManager>().isPause) // ���콺 ������ ��
            {
                // �� ���� ��ġ
                Vector3 linePos = new Vector3(transform.position.x + 3f, 4.5f, 0f);
                //Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ġ

                // �� ���۰� �� ��ġ ����
                lineRenderer.SetPosition(0, linePos);
                lineRenderer.SetPosition(1, transform.position);

                // Distance Joint 2D : Rigidbody 2D ���� ��Ģ�� �����ϴ� �� ���� ���� ������Ʈ�� �����ϰ� ������ ������ �����ϴ� 2D ����Ʈ
                distanceJoint.connectedAnchor = linePos;

                // �Ÿ� ����, �� Ȱ��ȭ
                distanceJoint.enabled = true;
                lineRenderer.enabled = true;

                //transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, transform.position.z);
                
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

            if (transform.position.y <= -5) // ���� ��ǥ
            {
                GameState(false);           // ���� ����
            }
        }
    }

    public void GameState(bool val) // true�̸� GameStart, false�̸� GameOver
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
