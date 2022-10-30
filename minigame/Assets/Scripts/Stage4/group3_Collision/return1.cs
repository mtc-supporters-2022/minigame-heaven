using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return1 : MonoBehaviour
{
    float time = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            this.time += Time.deltaTime;
            if(this.time > 4 && !(Time.timeScale == 0))
            {
                Time.timeScale = 1.0F;
            }
            if(this.time > 5)
            {
                GameObject.Find("GameManager").GetComponent<anicontrol>().Returning();
            }
            if(this.time > 5.5)
            {               
                gameObject.GetComponent<BoxCollider2D>().enabled = true;        
                time = 0f;
            }
        }
    }
}
