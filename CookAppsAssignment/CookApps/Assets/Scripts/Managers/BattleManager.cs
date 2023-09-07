using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public enum Line
    {
        Front,
        Mid,
        Back,

    }

    public List<Character> players = new List<Character>();
    public List<Character> enemies = new List<Character>();

    private Vector3 playerPivot = new Vector3(-4, 0, 0);
    private Vector3 enemyPivot = new Vector3(4, 0, 0);
    

    private static BattleManager m_instance;
    public static BattleManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<BattleManager>();
                if (m_instance == null)
                {
                    GameObject singletonObject = new GameObject("BattleManager");
                    m_instance = singletonObject.AddComponent<BattleManager>();
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
        SetCharactersSide();
    }

    // Update is called once per frame
    void Update()
    {
        //IsListEmpty();
    }

    public void InsertPlayer(List<Character> characters, Line line)
    {
        float yAxisPivot = 0f;
        bool isTwo = false;
        if (characters.Count <= 0)
        {
            return;
        }
        switch (characters.Count)
        {
            case 1:
                yAxisPivot = 0f;
                break;
            case 2:
                yAxisPivot = 1f;
                isTwo = true;
                break;
            case 3:
                yAxisPivot = 2f;
                break;
        }

        switch (line)
        {
            case Line.Front:
                SetPositions(characters, isTwo, -4f, yAxisPivot);
                break;
            case Line.Mid:
                SetPositions(characters, isTwo, -6f, yAxisPivot);
                break;
            case Line.Back:
                SetPositions(characters, isTwo, -8f, yAxisPivot);
                break;
        }

        foreach (var player in characters)
        {
            players.Add(player);
        }
    }

	public void InsertEnemy(List<Character> characters, Line line)
	{
		float yAxisPivot = 0f;
		bool isTwo = false;
		if (characters.Count <= 0)
		{
			return;
		}
		switch (characters.Count)
		{
			case 1:
				yAxisPivot = 0f;
				break;
			case 2:
				yAxisPivot = 1f;
				isTwo = true;
				break;
			case 3:
				yAxisPivot = 2f;
				break;
		}

		switch (line)
		{
			case Line.Front:
				SetPositions(characters, isTwo, 4f, yAxisPivot);
				break;
			case Line.Mid:
				SetPositions(characters, isTwo, 6f, yAxisPivot);
				break;
			case Line.Back:
				SetPositions(characters, isTwo, 8f, yAxisPivot);
				break;
		}

		foreach (var player in characters)
		{
			enemies.Add(player);
		}
	}

	private void SetPositions(List<Character> characters, bool isTwo, float xPivot, float yPivot)
    {
        float temp = yPivot;
        
        foreach (var cha in characters)
        {
            cha.transform.position = new Vector3(xPivot, temp, 0f);
            if (isTwo)
            {
                temp *= -1;
            }
            else
            {
                temp -= yPivot;
            }  
        }
    }

    private bool IsListEmpty()
    {
        if (players.Count <= 0)
        {
            return true;
        }
        if (enemies.Count <= 0)
        {
            return true;
        }
        return false;
    }

    public void SetCharactersSide()
    {
        foreach (var player in players)
        {
            player.side = Character.Side.Player;
            player.InitRotation();
        }

        foreach (var enemy in enemies)
        {
            enemy.side = Character.Side.Enemy;
			enemy.InitRotation();
		}
    }

    public bool GetIsPlayerAlive()
    {
        bool isAllAlive = false;

        foreach (var palyer in players)
        {
            if (palyer.gameObject.activeSelf)
            {
                isAllAlive = true;
                break;
            }
        }
        return isAllAlive;
    }

    public bool GetIsEnemyAlive()
    {
        bool isAllAlive = false;

        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                isAllAlive = true;
                break;
            }
        }
        return isAllAlive;
    }

    public void RemoveFromList(GameObject gameObject, Character.Side side)
    {
        Character character = gameObject.GetComponent<Character>();
        if (side == Character.Side.Player)
        {
            players.Remove(character);
        }
        else
        {
            enemies.Remove(character);
        }
    }
}
