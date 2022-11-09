using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bl_Joystick js;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(js.Horizontal, js.Vertical,0);   //스틱이 향해있는 방향을 변수에 저장
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;       //오브젝트의 위치를 dir방향으로 이동
        
    }
}
