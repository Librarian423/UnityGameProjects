using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> playerLine1 = new List<Character>();
    public List<Character> playerLine2 = new List<Character>();
    public List<Character> playerLine3 = new List<Character>();

    private static GameManager m_instance;
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
                if (m_instance == null)
                {
                    // 씬에 MySingleton 오브젝트가 없는 경우 새로 생성합니다.
                    GameObject singletonObject = new GameObject("BattleManager");
                    m_instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BattleManager.instance.InsertPlayerFront(playerLine1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
