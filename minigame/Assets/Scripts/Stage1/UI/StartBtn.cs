using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public GameObject touchScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        touchScreen.SetActive(false);
    }

    public void BtnClick()
    {
        Time.timeScale = 1f;
    }
}
