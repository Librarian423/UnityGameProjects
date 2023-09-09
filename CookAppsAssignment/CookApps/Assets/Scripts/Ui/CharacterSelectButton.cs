using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectButton : MonoBehaviour
{
    [SerializeField] private Character character;
	[SerializeField] bool isClicked = false;
	[SerializeField] private CharacterIcon icon;
	[SerializeField] private int buttonId;

	//Player Character Button
	public void ClickPlayerButton()
	{
		if (!isClicked)
		{
			SetPlayerOnLine();
			isClicked = true;
			
		}
		else
		{
			RemovePlayerOnLine();
			isClicked = false;
		}
	}

	public void SetId(int num)
	{
		buttonId = num;
	}

	public void SetIcon(CharacterIcon icon)
	{
		this.icon = icon;
	}

	private void SetPlayerOnLine()
    {
		switch (character.GetPosition())
		{
			case Stats.Position.Front:
				UiManager.instance.TrySetFront(character, buttonId);
				break;
			case Stats.Position.Middle:
				UiManager.instance.TrySetMiddle(character, buttonId);
				break;
			case Stats.Position.Back:
				UiManager.instance.TrySetBack(character, buttonId);
				break;
		}
	}

	private void RemovePlayerOnLine()
	{
		UiManager.instance.RemovePlayer(buttonId);

	}
}
