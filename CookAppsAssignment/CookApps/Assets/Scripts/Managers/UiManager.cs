using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	[Header("BattleUI")]
	[SerializeField] private GameObject skillButtons;
	[SerializeField] private SkillButton skillButton;

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
		DontDestroyOnLoad(gameObject);
	}
	
	public void SetPlayerLine1(Line line)
	{
		playerLine1 = line;
	}

	public void SetPlayerLine2(Line line)
	{
		playerLine2 = line;
	}

	public void SetPlayerLine3(Line line)
	{
		playerLine3 = line;
	}

	public void SetEnemyLine1(GameObject line)
	{
		enemyLine1 = line;
	}

	public void SetEnemyLine2(GameObject line)
	{
		enemyLine2 = line;
	}

	public void SetEnemyLine3(GameObject line)
	{
		enemyLine3 = line;
	}

	public void BattleStart()
	{
		//insert player
		InsertCharacters(playerLine1.gameObject, 1, true);
		InsertCharacters(playerLine2.gameObject, 2, true);
		InsertCharacters(playerLine3.gameObject, 3, true);

		//insert enemy
		InsertCharacters(enemyLine1, 1, false);
		InsertCharacters(enemyLine2, 2, false);
		InsertCharacters(enemyLine3, 3, false);
		
		//clear
		DestroyEnemyLineChildren();
		//Load Battle Scene
		SceneManager.LoadScene(2);
	}

	public void SetSkillButtons(GameObject gameObject)
	{
		skillButtons = gameObject;
	}

	public void SetSkillButtonWidth(int count)
	{
		skillButtons.GetComponent<SkillButtonSetter>().SetSize(count);
	}

	public void AddSkillButton(Character character)
	{
		var button = Instantiate(skillButton, skillButtons.transform);
		button.SetButton(character);
	}

	public void SetStage(Stage stage)
	{
		currentStage = stage;
		SetBattleInfoStageName(currentStage.GetStageName());
	}

	public void SetStageNameText(TextMeshProUGUI text)
	{
		stageName = text;
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

	//Insert characters in GameManager
	private void InsertCharacters(GameObject gameObject, int index, bool isPlayer)
	{
		var characters = gameObject.GetComponentsInChildren<CharacterIcon>().ToList();
		if (isPlayer)
		{
			foreach (var cha in characters)
			{
				InsertPlayer(cha.GetCharacter(), index);
			}
		}
		else
		{
			foreach (var cha in characters)
			{
				InsertEnemy(cha.GetCharacter(), index);
			}
		}
		
		
	}

	private void InsertPlayer(Character character, int index)
	{
		switch (index)
		{
			case 1:
				GameManager.instance.playerLine1.Add(character);
				break;
			case 2:
				GameManager.instance.playerLine2.Add(character);
				break;
			case 3:
				GameManager.instance.playerLine3.Add(character);
				break;
		}
	}

	private void InsertEnemy(Character character, int index)
	{
		switch (index)
		{
			case 1:
				GameManager.instance.enemyLine1.Add(character);
				break;
			case 2:
				GameManager.instance.enemyLine2.Add(character);
				break;
			case 3:
				GameManager.instance.enemyLine3.Add(character);
				break;
		}
	}

	//Check if line is full
	public void TrySetFront(Character character, int id)
	{
		if (playerLine1.IsFull())
		{
			SetReadyPlayerLine1(character, id);
		}
		else
		{
			TrySetMiddle(character, id);
		}
	}

	public void TrySetMiddle(Character character, int id)
	{
		if (playerLine2.IsFull())
		{
			SetReadyPlayerLine2(character, id);
		}
		else
		{
			TrySetBack(character, id);
		}
	}

	public void TrySetBack(Character character, int id)
	{
		if (playerLine3.IsFull())
		{
			SetReadyPlayerLine3(character, id);
		}
	}

	//Remove player from line
	public void RemovePlayer(int id)
	{
		//search line1
		var players = playerLine1.GetComponentsInChildren<CharacterIcon>().ToList();
		foreach (var player in players)
		{
			if (player.GetId().Equals(id))
			{
				Destroy(player.gameObject);
				playerLine1.DecreaseCount();
				return;
			}
		}

		//search line2
		players = playerLine2.GetComponentsInChildren<CharacterIcon>().ToList();
		foreach (var player in players)
		{
			if (player.GetId().Equals(id))
			{
				Destroy(player.gameObject);
				playerLine2.DecreaseCount();
				return;
			}
		}

		//search line3
		players = playerLine3.GetComponentsInChildren<CharacterIcon>().ToList();
		foreach (var player in players)
		{
			if (player.GetId().Equals(id))
			{
				Destroy(player.gameObject);
				playerLine3.DecreaseCount();
				return;
			}
		}
	}

	//Add images in player line and Set sprite

	//private void SetPlayer(CharacterIcon characterIcon, Sprite sprite)
	//{
	//	characterIcon.SetImageSprite(sprite);
	//	characterIcon.SetIsPlayer(true);
	//}

	private void SetReadyPlayerLine1(Character character, int id)
	{
		var icon = Instantiate(IconPrefab, playerLine1.transform);
		icon.SetId(id);
		icon.SetIcon(character);
		playerLine1.IncreaseCount();
	}

	private void SetReadyPlayerLine2(Character character, int id)
	{
		var icon = Instantiate(IconPrefab, playerLine2.transform);
		icon.SetId(id);
		icon.SetIcon(character);
		playerLine2.IncreaseCount();
	}

	private void SetReadyPlayerLine3(Character character, int id)
	{
		var icon = Instantiate(IconPrefab, playerLine3.transform);
		icon.SetId(id);
		icon.SetIcon(character);
		playerLine3.IncreaseCount();
	}


	//Add images in enemy line and Set sprite
	private void SetEnemy(CharacterIcon characterIcon,Sprite sprite)
	{
		characterIcon.SetImageSprite(sprite);
		characterIcon.SetIsPlayer(false);
	}

	public void SetReadyEnemyLine1(Character character)//, RuntimeAnimatorController animator)
	{
		var icon = Instantiate(IconPrefab, enemyLine1.transform);
		icon.SetIcon(character);
		//SetEnemy(icon, sprite);
		//icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

    public void SetReadyEnemyLine2(Character character)//, RuntimeAnimatorController animator)
    {
		var icon = Instantiate(IconPrefab, enemyLine2.transform);
		icon.SetIcon(character);
		//SetEnemy(icon, sprite);
		//icon.SetImageSprite(sprite);
		//icon.SetAnimator(animator);
	}

	public void SetReadyEnemyLine3(Character character)//, RuntimeAnimatorController animator)
	{
		var icon = Instantiate(IconPrefab, enemyLine3.transform);
		icon.SetIcon(character);
		//SetEnemy(icon, sprite);
		//icon.SetImageSprite(sprite);
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
