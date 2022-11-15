using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // �� ��ȯ ����

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int[] bestScore = new int[5]; // 0 ����ΰ� 1, 2, 3, 4 ���

    public static GameManager Instance
    {
        get
        {
            if (!_instance) // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ�
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);    // �ν��Ͻ��� �����ϴ� ��� ���� ����� �ν��Ͻ��� ����
        }

        DontDestroyOnLoad(gameObject); // ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʰ�
    }

    public void LoadScene(int idx)
    {
        switch (idx)
        {
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
            case 4:
                SceneManager.LoadScene("Stage4");
                break;
            case 5:
                SceneManager.LoadScene("MainScene");
                break;
        }
        
    }
}
