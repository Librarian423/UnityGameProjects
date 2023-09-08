using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static BattleManager;

public class UiManager : MonoBehaviour
{
	[Header("BattleInfo")]
	[SerializeField] private TextMeshProUGUI stageName;
	[SerializeField] private Stage currentStage;

	[Header("BattleReady")]
	[SerializeField] private Line playerLine1;
	[SerializeField] private Line playerLine2;
	[SerializeField] private Line playerLine3;

	[SerializeField] private GameObject enemyLine1;
    [SerializeField] private GameObject enemyLine2;
	[SerializeField] private GameObject enemyLine3;

	[SerializeField] private CharacterIcon IconPrefab;

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

	//Ready Button
	public void OnClickReadyButton()
	{
		currentStage.SetReadyEnemies();
	}

	//Player Character Button
	//public void OnClickPlayerButton(Character character)
	//{
	//	switch (character.GetPosition())
	//	{
	//		case Stats.Position.Front:
	//			TrySetFront(character);
	//			break;
	//		case Stats.Position.Middle:
	//			TrySetMiddle(character);
	//			break;
	//		case Stats.Position.Back:
	//			TrySetBack(character);
	//			break;

	//	}
	//}

	//Check if line is full
	public void TrySetFront(Character character)
	{
		if (playerLine1.IsFull())
		{
			playerLine1.IncreaseCount();
			SetReadyPlayerLine1(character.GetProfile());	
		}
		else
		{
			TrySetMiddle(character);
		}
	}

	public void TrySetMiddle(Character character)
	{
		if (playerLine2.IsFull())
		{
			playerLine2.IncreaseCount();
			SetReadyPlayerLine2(character.GetProfile());
		}
		else
		{
			TrySetBack(character);
		}
	}

	public void TrySetBack(Character character)
	{
		if (playerLine3.IsFull())
		{
			playerLine3.IncreaseCount();
			SetReadyPlayerLine3(character.GetProfile());
		}
		else
		{
			PopUpBanner();
		}
	}

	public void PopUpBanner()
	{

	}

	private void SetReadyPlayerLine1(Sprite sprite)
	{
		var icon = Instantiate(IconPrefab, playerLine1.transform);
		icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

	private void SetReadyPlayerLine2(Sprite sprite)
	{
		var icon = Instantiate(IconPrefab, playerLine2.transform);
		icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

	private void SetReadyPlayerLine3(Sprite sprite)
	{
		var icon = Instantiate(IconPrefab, playerLine3.transform);
		icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

	//Add images in line and Set sprite
	public void SetReadyEnemyLine1(Sprite sprite)//, RuntimeAnimatorController animator)
	{
		var icon = Instantiate(IconPrefab, enemyLine1.transform);
		icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

    public void SetReadyEnemyLine2(Sprite sprite)//, RuntimeAnimatorController animator)
    {
		var icon = Instantiate(IconPrefab, enemyLine2.transform);
		icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

    public void SetReadyEnemyLine3(Sprite sprite)//, RuntimeAnimatorController animator)
	{
		var icon = Instantiate(IconPrefab, enemyLine3.transform);
		icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

	//Destroy all child objects of enemy line
	public void DestroyEnemyLineChildren()
	{
		Transform parentTransform = enemyLine1.transform;
		DestroyLineChildren(parentTransform);

		parentTransform = enemyLine2.transform;
		DestroyLineChildren(parentTransform);

		parentTransform = enemyLine3.transform;
		DestroyLineChildren(parentTransform);
	}

	//Destroy all child objects
	private void DestroyLineChildren(Transform parent)
	{	
		foreach (Transform child in parent)
		{
			Destroy(child.gameObject);
		}
	}
}
