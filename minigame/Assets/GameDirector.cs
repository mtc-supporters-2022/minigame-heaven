using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject pointText;
    int point = 0;
    int level = 1;
    float pTime = 0f;
    float time = 0f;
    GameObject generator;

    public void GetBox()
    {
        this.point += 100;
    }

    public void TimeBonus()
    {
        this.point += 1;
    }

    void Start()
    {
        this.generator = GameObject.Find("GameManager");
        this.pointText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        this.pTime += Time.deltaTime;
        if (this.pTime > 5) 
        {
            this.pTime = 0;
            this.point += 10*level;
        }
        if(this.time > 0 && this.time <= 3)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -7.0f);
            this.level = 1;
        }else if(this.time > 3 && this.time <= 6)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -7.5f);
            this.level = 2;
        }
        else if (this.time > 6 && this.time <= 9)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.95f, -8f);
            this.level = 3;
        }
        else if (this.time > 9 && this.time <= 12)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.95f, -8.5f);
            this.level = 4;
        }
        else if (this.time > 12 && this.time <= 15) 
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -9f);
            this.level = 5;
        }
        else if (this.time > 15 && this.time <= 18)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.9f, -9.5f);
            this.level = 6;
        }
        else if (this.time > 18 && this.time <= 21)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.85f, -10f);
            this.level = 7;
        }
        else if (this.time > 21 && this.time <= 24)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.85f, -10.5f);
            this.level = 8;
        }
        else if (this.time > 24 && this.time <= 27)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -11f);
            this.level = 9;
        }
        else if (this.time > 27 && this.time <= 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.75f, -13f);
            this.level = 10;
        }
        else if (this.time > 30 && this.time <= 33)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -15f);
            this.level = 11;
        }
        else if (this.time > 33 && this.time <= 36)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.6f, -17f);
            this.level = 12;
        }
        else if (this.time > 36)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -19f);
            this.level = 13;
        }

        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }
}
