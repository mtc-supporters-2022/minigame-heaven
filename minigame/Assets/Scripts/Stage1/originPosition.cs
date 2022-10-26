using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class originPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 originPos;
    public Vector3 nextPos;

    private void Start()
    {
        originPos = transform.position;
        nextPos= transform.position + (Vector3.left*0.5f);
    }

    public void nextPosUpdate()
    {
        originPos = transform.position;
        nextPos = transform.position + (Vector3.left * 0.5f);
    }
}
