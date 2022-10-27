using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject bulletPrefeb;    //GameController 에서는 총알 생성까지만        
    public GameObject uiEndGameObject;
    public Text TIME;
    int sec;
    // Start is called before the first frame update
    void Start()
    {
        sec = 90;       // 90초 버티기

        InvokeRepeating("MakeBullet", 0f, 1f);        //반복적으로 "MakeBullet"함수호출
        InvokeRepeating("SetTime", 1f, 1f);           //반복적으로 "SetTime"함수호출
    }

    void SetTime(){                   //1초마다 sec값 1감소
        sec = sec - 1;
        TIME.text = ""+sec;
    }

    void MakeBullet(){                   //총알 생성

        GameObject bullet;

        float switchValue = Random.value;          //총알이 출현할 x,y값 랜덤 지정
        float xValue = Random.Range(0f,360f);
        float yValue = Random.Range(0f,640f);

        Debug.Log("switchValue : " + switchValue + ", xValue : " + xValue + ", yValue : " + yValue);   //콘솔창에서 실행 검사

        if(switchValue > 0.5f){
            if(Random.value > 0.5f){
                bullet = Instantiate(bulletPrefeb, new Vector3(0f, yValue, 0f), Quaternion.identity);
            }
            else{
                bullet = Instantiate(bulletPrefeb, new Vector3(360f, yValue, 0f), Quaternion.identity);
            }
        }
        else{
            if(Random.value > 180f){
                bullet = Instantiate(bulletPrefeb, new Vector3(xValue,0f,0f), Quaternion.identity);
            }
            else{
                bullet = Instantiate(bulletPrefeb, new Vector3(xValue,640f,0), Quaternion.identity);
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
