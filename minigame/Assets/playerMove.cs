using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    int posx = 0;

    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);

        if (posx > -2)
        {
            if (Input.GetMouseButtonDown(0) == true && mousePos.x<720)
            {
                posx = posx - 1;
            }
        }
        if (Input.GetMouseButton(0) == true && mousePos.x < 720)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(posx,-4,0), 0.05f);

        }
        if (Input.GetMouseButtonUp(0) == true && mousePos.x < 720)
        {
            gameObject.transform.position = (new Vector3(posx,-4 , 0));
        }
        if (posx < 2)
        {
            if (Input.GetMouseButtonDown(0) == true && mousePos.x > 720)
            {
                posx = posx + 1;
            }
        }
        if (Input.GetMouseButton(0) == true && mousePos.x > 720)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(posx,-4,0), 0.05f);
        }
        if (Input.GetMouseButtonUp(0) == true && mousePos.x > 720)
        {
            gameObject.transform.position = (new Vector3(posx,-4 , 0));
        }
    }

}
