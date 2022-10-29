using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Vector3 targetPos;
    Vector3 myPos;    
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.Find("player").transform.position;
        myPos = transform.position;         // 복제되어 생성된 아이템 위치 대입
        newPos = (targetPos - myPos) * 0.0005f;  // 아이템속도 변경

        Destroy(gameObject, 15f);       //아이템소멸(제거할오브젝트, 지연시간)
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + newPos;   // 목표로 이동

    }
}
