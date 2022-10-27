using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 targetPos;
    Vector3 myPos;    
    Vector3 newPos;

    void Start()
    {
        targetPos = GameObject.Find("player").transform.position;
        myPos = transform.position;         // 복제되어 생선된 총알 위치 대입
        newPos = (targetPos - myPos) * 0.003f;  // 총알속도 변경

        Destroy(gameObject, 10f);       //총알소멸(제거할오브젝트, 지연시간)
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + newPos;   // 목표로 이동
    }
}
