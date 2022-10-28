using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){    //충돌감지
        Heart.hp -= 1;         //충동 시 생명력 1감소
        Debug.Log(Heart.hp);
        Destroy(collider.gameObject);   // 충돌한 bullet 파괴
        //Debug.Log("GAME OVER");
    }
}
