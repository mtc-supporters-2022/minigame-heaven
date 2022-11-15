using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject pauseBtn;
    public GameObject pausePnl;
    public GameObject gameoverPnl;

    public bool isPause;

    public void Pause(bool pause)
    {
        if (pause)
        {
            isPause = true;
            pausePnl.SetActive(true);
            Time.timeScale = 0;
            pauseBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            isPause = false;
            pausePnl.SetActive(false);
            Time.timeScale = 1;
            pauseBtn.GetComponent<Button>().interactable = true;
        }
    }
}
