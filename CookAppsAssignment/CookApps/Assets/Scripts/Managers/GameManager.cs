using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> playerLine1 = new List<Character>();
    public List<Character> playerLine2 = new List<Character>();
    public List<Character> playerLine3 = new List<Character>();

	public List<Character> enemyLine1 = new List<Character>();
	public List<Character> enemyLine2 = new List<Character>();
	public List<Character> enemyLine3 = new List<Character>();

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
        BattleManager.instance.InsertPlayer(playerLine1, BattleManager.Line.Front);
        BattleManager.instance.InsertPlayer(playerLine2, BattleManager.Line.Mid);
        BattleManager.instance.InsertPlayer(playerLine3, BattleManager.Line.Back);

		BattleManager.instance.InsertEnemy(enemyLine1, BattleManager.Line.Front);
		BattleManager.instance.InsertEnemy(enemyLine2, BattleManager.Line.Mid);
		BattleManager.instance.InsertEnemy(enemyLine3, BattleManager.Line.Back);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
