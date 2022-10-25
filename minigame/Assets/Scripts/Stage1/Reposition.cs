using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void LateUpdate()
    {
        if (transform.position.x > -5.7)
            return;



        transform.Translate(14.1f, 0, 0, Space.Self);
    }
}
