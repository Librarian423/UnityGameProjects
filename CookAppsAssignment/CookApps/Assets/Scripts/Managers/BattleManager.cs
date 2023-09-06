using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public List<Enemy> enemies = new List<Enemy>();

    private static BattleManager m_instance;
    public static BattleManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<BattleManager>();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCharacters()
    {

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
}
