using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �浹�ϸ� ������ �����Ѵ�
public class block : MonoBehaviour
{

    public string targetObjectName; // ��ǥ ������Ʈ �̸� : Inspector�� ����
    public string showObjectName;   // ǥ�� ������Ʈ �̸� : Inspector�� ����

    GameObject showObject;

    void Start()
    { // ó���� �����Ѵ�
      // �ð��� �����δ�
        
        Time.timeScale = 1;
        // ����� ���� ǥ�� ������Ʈ�� ����� �д� 
        showObject = GameObject.Find(showObjectName);
        showObject.SetActive(false); // �����
    }

    void OnCollisionEnter2D(Collision2D collision)// �浹���� ��
    {
        if (collision.gameObject.name == targetObjectName)
        {

            showObject.SetActive(true);

        }
        // ���� �浹�� ���� �̸��� ��ǥ ������Ʈ���ٸ�
        if (collision.gameObject.name == targetObjectName)
        {
            
            // �ð��� �����
            Time.timeScale = 0;

        }
    }
}

