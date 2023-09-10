using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
	public void DestroyEnemyLine()
	{
		UiManager.instance.DestroyEnemyLineChildren();
	}

	public void ReadyButton()
	{
		UiManager.instance.OnClickReadyButton();
	}

	public void BattleStart()
	{
		UiManager.instance.BattleStart();
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void GotoMain()
	{
		BattleManager.instance.ResetGame();
		SceneManager.LoadScene(1);
	}
}
