using UnityEngine;
using System.Collections;
public class Control : MonoBehaviour {
       // Update is called once per frame
        int speed=300; //스피드
       float xMove,yMove;
       void Update () {
              xMove = 0;
              yMove = 0;

              if (Input.GetKey(KeyCode.RightArrow))
                     xMove = speed * Time.deltaTime;
              else if (Input.GetKey(KeyCode.LeftArrow))
                     xMove = -speed * Time.deltaTime;
              if (Input.GetKey(KeyCode.UpArrow))
                     yMove = speed * Time.deltaTime;
              else if (Input.GetKey(KeyCode.DownArrow))
                     yMove = -speed * Time.deltaTime;
              this.transform.Translate(new Vector3(xMove,yMove,0));
       }
}