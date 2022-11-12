using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject pausePnl;
    public GameObject gameoverPnl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseBtn(bool pause)
    {
        if (pause)
        {
            pausePnl.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausePnl.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
