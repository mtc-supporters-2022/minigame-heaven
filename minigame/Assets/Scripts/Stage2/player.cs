using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("player").GetComponent<Heart>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)    //충돌감지
    {
        if(collider.gameObject.name == "bullet(Clone)")
        {
            DecreaseHP();  //충동 시 생명력 1감소
            Destroy(collider.gameObject);   // 충돌한 bullet 파괴
        }
         if(collider.gameObject.name == "item(Clone)")
         {
            Destroy(collider.gameObject);   // 충돌한 bullet 파괴
            GameObject.Find("game").GetComponent<GameController>().ItemSetTime();
            // Time.timeScale += 10;
        }
    }

    void DecreaseHP() 
    {
        HP -= 1;
        if (HP == 0)
        {
            //gameover();
        }
    }
}
