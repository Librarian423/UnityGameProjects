using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
	[Header("BattleInfo")]
	[SerializeField] private TextMeshProUGUI stageName;
	[SerializeField] private Stage currentStage;

	[Header("BattleReady")]
	[SerializeField] private Line enemyLine1;
    [SerializeField] private Line enemyLine2;
	[SerializeField] private Line enemyLine3;

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
					GameObject singletonObject = new GameObject("UiManager");
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

	public void BattleStart()
	{
		//GameManager.instance
		//Load Battle Scene
		SceneManager.LoadScene(2);
    }

	public void SetStage(Stage stage)
	{
		currentStage = stage;
		SetBattleInfoStageName(currentStage.GetStageName());

    }

	public void SetBattleInfoStageName(string name)
	{
		stageName.text = name;
    }

	public void OnClickBattleInfoNext()
	{		
		if (currentStage.GetNextStage() != null)
		{
			var temp = currentStage.GetNextStage();
			currentStage = temp;

			SetStage(currentStage);
        }		
	}

    public void OnClickBattleInfoPrev()
    {
        if (currentStage.GetPrevStage() != null)
        {
            var temp = currentStage.GetPrevStage();
            currentStage = temp;

            SetStage(currentStage);
        }
    }

	public void OnClickReadyButton()
	{
		currentStage.SetReadyEnemies();
	}

	//enable images on line and change sprite
	public void SetReadyEnemyImageLine1(Sprite sprite)
	{

	}

    public void SetReadyEnemyImageLine2()
    {

    }

    public void SetReadyEnemyImageLine3()
    {

    }
}
