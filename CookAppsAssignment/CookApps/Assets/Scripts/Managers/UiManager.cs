using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

	private static UiManager m_instance;
	public static UiManager instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = FindObjectOfType<UiManager>();
				if (m_instance == null)
				{
					GameObject singletonObject = new GameObject("BattleManager");
					m_instance = singletonObject.AddComponent<UiManager>();
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
        
    }
}
