using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public string showObjectName;
    public string showObjectName1;
    bool pauseActive = false;

    GameObject showObject;
    GameObject showObject1;
    // Start is called before the first frame update
    void Start()
    {   
        showObject = GameObject.Find(showObjectName);
        showObject1 = GameObject.Find(showObjectName1);
        showObject.SetActive(false); // Áö¿î´Ù
    }

    public void pauseBtn()
    {
        if (pauseActive)
        {
            showObject.SetActive(false);
            showObject1.SetActive(true);
            Time.timeScale = 1;
            pauseActive = false;
        }
        else
        {
            showObject.SetActive(true);
            showObject1.SetActive(false);
            Time.timeScale = 0;
            pauseActive = true;
        }
    }
}
