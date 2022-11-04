using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject block_11;
    public GameObject star;
    public GameObject Square;
    float span = 1.0f;
    float delta = 0;
    float speed = -7f;

    public void SetParameter(float span, float speed)
    {
        this.span = span;
        this.speed = speed;
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        
        Square.GetComponent<Create>().intervalSec = this.span;
        block_11.GetComponent<Forever_MoveV>().speed = this.speed;
        star.GetComponent<Forever_MoveV>().speed = this.speed;

    }
}
