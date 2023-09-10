using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Character> playerLine1 = new List<Character>();
    public List<Character> playerLine2 = new List<Character>();
    public List<Character> playerLine3 = new List<Character>();

	public List<Character> enemyLine1 = new List<Character>();
	public List<Character> enemyLine2 = new List<Character>();
	public List<Character> enemyLine3 = new List<Character>();

    [Header("Managers")]
    [SerializeField] private GameObject battleManager;

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
                    GameObject singletonObject = new GameObject("GameManager");
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
		DontDestroyOnLoad(gameObject);
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		SetBattleScene();
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private int GetTotalPlayerCount()
	{
		int total = 0;
		total += playerLine1.Count;
		total += playerLine2.Count;
		total += playerLine3.Count;
		return total;
	}

	public void SetBattleScene()
	{
		//Debug.Log(SceneManager.GetActiveScene().buildIndex);
		if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			battleManager.SetActive(true);
			UiManager.instance.SetSkillButtonWidth(GetTotalPlayerCount());

			MakeCharacters();			
			BattleManager.instance.SetCharactersSide();
		}
	}

	//Instantiate characters
    private void MakeCharacters()
    {
		//player
        if (playerLine1.Count > 0)
        {
            foreach (var cha in playerLine1)
            {
				var temp = Instantiate(cha);
				
				BattleManager.instance.players.Add(temp);
				BattleManager.instance.InsertPlayer(temp, playerLine1.Count, BattleManager.Line.Front);
				UiManager.instance.AddSkillButton(temp);
			}
			BattleManager.instance.ResetPivot();

		}
		
		if (playerLine2.Count > 0)
		{
			foreach (var cha in playerLine2)
			{
				var temp = Instantiate(cha);

				BattleManager.instance.players.Add(temp);
				BattleManager.instance.InsertPlayer(temp, playerLine2.Count, BattleManager.Line.Mid);
				UiManager.instance.AddSkillButton(temp);
			}
			BattleManager.instance.ResetPivot();
		}

		if (playerLine3.Count > 0)
		{
			foreach (var cha in playerLine3)
			{
				var temp = Instantiate(cha);

				BattleManager.instance.players.Add(temp);
				BattleManager.instance.InsertPlayer(temp, playerLine3.Count, BattleManager.Line.Back);
				UiManager.instance.AddSkillButton(temp);
			}
			BattleManager.instance.ResetPivot();
		}

		//enemy
		if (enemyLine1.Count > 0)
		{
			foreach (var cha in enemyLine1)
			{
				var temp = Instantiate(cha);
				BattleManager.instance.enemies.Add(temp);
				BattleManager.instance.InsertEnemy(temp, enemyLine1.Count, BattleManager.Line.Front);
			}
			BattleManager.instance.ResetPivot();
		}

		if (enemyLine2.Count > 0)
		{
			foreach (var cha in enemyLine2)
			{
				var temp = Instantiate(cha);
				BattleManager.instance.enemies.Add(temp);
				BattleManager.instance.InsertEnemy(temp, enemyLine2.Count, BattleManager.Line.Mid);
			}
			BattleManager.instance.ResetPivot();
		}

		if (enemyLine3.Count > 0)
		{
			foreach (var cha in enemyLine3)
			{
				var temp = Instantiate(cha);
				BattleManager.instance.enemies.Add(temp);
				BattleManager.instance.InsertEnemy(temp, enemyLine3.Count, BattleManager.Line.Back);
			}
			BattleManager.instance.ResetPivot();
		}
	}
}
