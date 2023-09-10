using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float y = 0f;
    private float negative = 1f;
    

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
		DontDestroyOnLoad(gameObject);
	}

    private void Update()
    {
        //Game Clear
        if (SceneManager.GetActiveScene().buildIndex == 2 && IsListEmpty()) 
        {
            GameManager.instance.playerLine1.Clear();
			GameManager.instance.playerLine2.Clear();
			GameManager.instance.playerLine3.Clear();
			GameManager.instance.enemyLine1.Clear();
			GameManager.instance.enemyLine2.Clear();
			GameManager.instance.enemyLine3.Clear();
			players.Clear();
            enemies.Clear();
			SceneManager.LoadScene(1);
		}
    }

    public void InsertPlayer(Character character, int count, Line line)
    {
        float yAxisPivot = 0f;
        bool isTwo = false;
        if (count <= 0)
        {
            return;
        }
        switch (count)
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
                SetPositions(character, isTwo, -4f, yAxisPivot);
                break;
            case Line.Mid:
                SetPositions(character, isTwo, -6f, yAxisPivot);
                break;
            case Line.Back:
                SetPositions(character, isTwo, -8f, yAxisPivot);
                break;
        }

        //foreach (var player in characters)
        //{
        //    players.Add(player);
        //}
    }

	public void InsertEnemy(Character character, int count, Line line)
	{
		float yAxisPivot = 0f;
		bool isTwo = false;
		if (count <= 0)
		{
			return;
		}
		switch (count)
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
				SetPositions(character, isTwo, 4f, yAxisPivot);
				break;
			case Line.Mid:
				SetPositions(character, isTwo, 6f, yAxisPivot);
				break;
			case Line.Back:
				SetPositions(character, isTwo, 8f, yAxisPivot);
				break;
		}

		//foreach (var player in characters)
		//{
		//	enemies.Add(player);
		//}
	}

	private void SetPositions(Character character, bool isTwo, float xPivot, float yPivot)
    {
        float temp = yPivot * negative - y;
		character.transform.position = new Vector3(xPivot, temp, 0f);
		if (isTwo)
        {
            negative *= -1f;
		}
        else
        {
            y += yPivot;
			negative = 1f;
		}
        
        //foreach (var cha in characters)
        //{
        //    cha.transform.position = new Vector3(xPivot, temp, 0f);
        //    if (isTwo)
        //    {
        //        temp *= -1;
        //    }
        //    else
        //    {
        //        temp -= yPivot;
        //    }  
        //}
    }

    public void ResetPivot()
    {
        y = 0f;
        negative = 1f;
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
