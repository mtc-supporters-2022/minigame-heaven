using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    int posx = 0;
    void Update()
    {
        if (posx > -2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                posx = posx - 1;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(posx,-4,0), 0.05f);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            gameObject.transform.position = (new Vector3(posx,-4 , 0));
        }
        if (posx < 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                posx = posx + 1;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(posx,-4,0), 0.05f);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            gameObject.transform.position = (new Vector3(posx,-4 , 0));
        }
    }
}
