using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Text CountText;
    public int num;
    public Timer timer;
    public GameObject touchScreen;
    // Start is called before the first frame update
    void Start()
    {
        CountText = gameObject.GetComponent<Text>();
        CountText.text = num.ToString();
        StartCoroutine(Count());
    }


    IEnumerator Count()
    {
        if (num <= 0)
        {
            touchScreen.SetActive(true);
            timer.gameObject.SetActive(true);
            timer.setPause(false);
            gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        num--;
        CountText.text = num.ToString();
        StartCoroutine(Count());
        
    }
}
