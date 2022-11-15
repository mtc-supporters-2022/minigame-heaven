using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환 위함

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int[] bestScore = new int[5]; // 0 비워두고 1, 2, 3, 4 사용

    public static GameManager Instance
    {
        get
        {
            if (!_instance) // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당
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
            Destroy(gameObject);    // 인스턴스가 존재하는 경우 새로 생기는 인스턴스를 삭제
        }

        DontDestroyOnLoad(gameObject); // 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않게
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
