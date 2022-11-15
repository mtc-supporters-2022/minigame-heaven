using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public GameObject noBtn;
    public GameObject yesBtn;
    public GameObject gameoverPnl;

    public bool cliqueYes = false;
    public bool cliqueNo = false;

    void Start()
    {
        //gameoverPnl.SetActive(false); // Áö¿î´Ù
    }

    // play again_yes
    public void Yes(bool clique)
    {
        if (clique)
        {
            cliqueYes = true;
            gameoverPnl.SetActive(true);
            Time.timeScale = 0;
            yesBtn.GetComponent<Button>().interactable = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         
        }
        else
        {
            cliqueYes = false;
            gameoverPnl.SetActive(false);
            Time.timeScale = 1;
            yesBtn.GetComponent<Button>().interactable = true;
        }
    }

    public void no(bool clique)
    {
        if (clique)
        {
            cliqueNo = true;
            gameoverPnl.SetActive(true);
            Time.timeScale = 0;
            noBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            cliqueNo = false;
            gameoverPnl.SetActive(false);
            Time.timeScale = 1;
            noBtn.GetComponent<Button>().interactable = true;
        }
    }

}
