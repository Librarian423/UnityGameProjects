using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Prefabs")]
    public GameObject player;

    [Header("Rounds")]
    private int firstRound = 1;
    public int round;

    private static GameManager m_instance; 
    public static GameManager instance
    {
        get
        { 
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
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
        round = firstRound;

    }

    private void Start()
    {
        //Instantiate(player, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
