using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLine : MonoBehaviour
{
	[Header("EnemyLine")]
	[SerializeField] private GameObject enemyLine1;
	[SerializeField] private GameObject enemyLine2;
	[SerializeField] private GameObject enemyLine3;

	// Start is called before the first frame update
	void Start()
    {
		UiManager.instance.SetEnemyLine1(enemyLine1);
		UiManager.instance.SetEnemyLine2(enemyLine2);
		UiManager.instance.SetEnemyLine3(enemyLine3);
	}

}
