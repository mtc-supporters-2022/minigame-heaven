using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollision : MonoBehaviour
{
    public string targetObjectName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)// �浹���� ��
    {
        // ���� �浹�� ���� �̸��� ��ǥ ������Ʈ�� 
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject.Find("GameManager").GetComponent<anicontrol>().Mujeok();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Time.timeScale = 3.0F;
        }
    }
}
