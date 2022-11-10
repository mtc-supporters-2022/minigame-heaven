using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Torch : MonoBehaviour
{
    private new UnityEngine.Experimental.Rendering.Universal.Light2D light;

    private bool upDown;
    public float startLight;
    public float endLight;
    private float memoryLight;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        upDown = false;
        memoryLight = startLight;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!upDown)
            startLight = Mathf.Lerp(startLight, endLight, Time.deltaTime*speed);
        else
            startLight = Mathf.Lerp(startLight, memoryLight, Time.deltaTime* speed);

        light.pointLightOuterRadius = startLight;

        if (light.pointLightOuterRadius > endLight-0.05f)
        {
            upDown = true;
        }
        else if (light.pointLightOuterRadius < memoryLight+0.05f)
        {
            upDown = false;
        }


    }
}
