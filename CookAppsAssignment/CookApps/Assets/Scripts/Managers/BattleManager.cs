using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Character> players = new List<Character>();
    public List<Character> enemies = new List<Character>();

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
                    // 씬에 MySingleton 오브젝트가 없는 경우 새로 생성합니다.
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
        IsListEmpty();
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

    private void SetCharactersSide()
    {
        foreach (var player in players)
        {
            player.side = Character.Side.Player;
        }

        foreach (var enemy in enemies)
        {
            enemy.side = Character.Side.Enemy;
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
