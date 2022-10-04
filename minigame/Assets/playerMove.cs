using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    int posx = 0;
    int posy = -450;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            posx = posx - 144;
        }
        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(posx, posy), 0.05f);
            
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            gameObject.transform.position = (new Vector3(posx, posy, 0));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            posx = posx + 144;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(posx, posy), 0.05f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            gameObject.transform.position = (new Vector3(posx, posy, 0));
        }
    }
}
