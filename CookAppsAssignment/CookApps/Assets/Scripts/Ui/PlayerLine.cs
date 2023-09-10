using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
	[Header("PlayerLine")]
	[SerializeField] private Line playerLine1;
	[SerializeField] private Line playerLine2;
	[SerializeField] private Line playerLine3;

	// Start is called before the first frame update
	void Start()
    {
		UiManager.instance.SetPlayerLine1(playerLine1);
		UiManager.instance.SetPlayerLine2(playerLine2);
		UiManager.instance.SetPlayerLine3(playerLine3);
	}
}
