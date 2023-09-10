using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<Stage> stages = new List<Stage>();

    private static StageManager m_instance;
    public static StageManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<StageManager>();
                if (m_instance == null)
                {
                    GameObject singletonObject = new GameObject("StageManager");
                    m_instance = singletonObject.AddComponent<StageManager>();
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
