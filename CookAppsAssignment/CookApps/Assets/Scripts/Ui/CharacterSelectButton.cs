using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectButton : MonoBehaviour
{
    [SerializeField] private Character character;
	[SerializeField] bool isClicked = false;

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

		}
	}

	private void SetPlayerOnLine()
    {
		switch (character.GetPosition())
		{
			case Stats.Position.Front:			
				UiManager.instance.TrySetFront(character);
				break;
			case Stats.Position.Middle:
				UiManager.instance.TrySetMiddle(character);
				break;
			case Stats.Position.Back:
				UiManager.instance.TrySetBack(character);
				break;
		}
	}

	private void RemovePlayerOnLine(Character character)
	{

	}
}
