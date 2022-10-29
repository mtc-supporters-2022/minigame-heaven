using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 때때로 범위 내에 랜덤으로 프리팹을 만든다
public class Create : MonoBehaviour
{

    public GameObject newPrefab;// 만드는 프리팹 ：Inspector에 지정한다
    public GameObject item;
    public float intervalSec = 1; // 작성 간격（초）：Inspector로에 지정한다
    float time = 0f;
    int deleteRock;
    int tmp;
    int count;

    void Start()
    { // 처음에 시행한다
      // 지정 초 수마다 CreatePrefab를 반복 실행하는 예약
        deleteRock = Random.Range(1, 6);
        tmp = deleteRock;
        count = 0;
        
    }

    void Update()
    {
        this.time += Time.deltaTime;
        if(this.time > intervalSec)
        {
            Vector3 area = GetComponent<SpriteRenderer>().bounds.size;

            Vector3 newPos1 = this.transform.position;
            Vector3 newPos2 = this.transform.position;
            Vector3 newPos3 = this.transform.position;
            Vector3 newPos4 = this.transform.position;
            Vector3 newPos5 = this.transform.position;

            while (deleteRock == tmp)
            {
                deleteRock = Random.Range(1, 6);
            }
            tmp = deleteRock;
            if (deleteRock == 1)
            {
                newPos1.x += 2 - 3;
                newPos1.y += 0;
                newPos2.x += 3 - 3;
                newPos2.y += 0;
                newPos3.x += 4 - 3;
                newPos3.y += 0;
                newPos4.x += 5 - 3;
                newPos4.y += 0;
            }
            else if (deleteRock == 2)
            {
                newPos1.x += 1 - 3;
                newPos1.y += 0;
                newPos2.x += 3 - 3;
                newPos2.y += 0;
                newPos3.x += 4 - 3;
                newPos3.y += 0;
                newPos4.x += 5 - 3;
                newPos4.y += 0;
            }
            else if (deleteRock == 3)
            {
                newPos1.x += 1 - 3;
                newPos1.y += 0;
                newPos2.x += 2 - 3;
                newPos2.y += 0;
                newPos3.x += 4 - 3;
                newPos3.y += 0;
                newPos4.x += 5 - 3;
                newPos4.y += 0;
            }
            else if (deleteRock == 4)
            {
                newPos1.x += 1 - 3;
                newPos1.y += 0;
                newPos2.x += 2 - 3;
                newPos2.y += 0;
                newPos3.x += 3 - 3;
                newPos3.y += 0;
                newPos4.x += 5 - 3;
                newPos4.y += 0;
            }
            else if (deleteRock == 5)
            {
                newPos1.x += 1 - 3;
                newPos1.y += 0;
                newPos2.x += 2 - 3;
                newPos2.y += 0;
                newPos3.x += 3 - 3;
                newPos3.y += 0;
                newPos4.x += 4 - 3;
                newPos4.y += 0;
            }
            if (count == 10)
            {
                
                newPos5.x += deleteRock - 3;
                newPos5.y += 0;
                newPos5.z = -5;
                
                GameObject newGameObject5 = Instantiate(item) as GameObject;
                newGameObject5.transform.position = newPos5;

                count = 0;
            }


            newPos1.z = -5;
            newPos2.z = -5;
            newPos3.z = -5;
            newPos4.z = -5;// 앞 쪽에 표시
                           // 프리팹을 만든다
            GameObject newGameObject1 = Instantiate(newPrefab) as GameObject;
            newGameObject1.transform.position = newPos1;

            GameObject newGameObject2 = Instantiate(newPrefab) as GameObject;
            newGameObject2.transform.position = newPos2;

            GameObject newGameObject3 = Instantiate(newPrefab) as GameObject;
            newGameObject3.transform.position = newPos3;

            GameObject newGameObject4 = Instantiate(newPrefab) as GameObject;
            newGameObject4.transform.position = newPos4;

            count += 1;

            this.time = 0;
        }
        
    }
}
