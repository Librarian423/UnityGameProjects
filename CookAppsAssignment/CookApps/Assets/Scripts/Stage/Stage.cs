using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage : MonoBehaviour
{
    [Header("Name")]
    [SerializeField] private string StageName;

    [Header("Enemy Lists")]
    [SerializeField] private List<Character> Line1enemies;
    [SerializeField] private List<Character> Line2enemies;
    [SerializeField] private List<Character> Line3enemies;

    [Header("Connected Stage")]
    [SerializeField] private Stage prevStage;
    [SerializeField] private Stage nextStage;

    private TextMeshProUGUI stageTextName;

    private void Start()
    {
        stageTextName = GetComponentInChildren<TextMeshProUGUI>();

        stageTextName.text = StageName;
    }

    public string GetStageName()
    {
        return StageName;
    }

    public Stage GetNextStage()
    {
        if (nextStage != null)
        {
            return nextStage;
        }
        return null;
    }

    public Stage GetPrevStage()
    {
        if (prevStage != null)
        {
            return prevStage;
        }
        return null;
    }

    //set enemy image on line
    public void SetReadyEnemies()
    {
        if (Line1enemies.Count > 0)
        {
            foreach (var enemy in Line1enemies)
            {
                UiManager.instance.SetReadyEnemyLine1(enemy.GetProfile());//, enemy.GetAnimator());
            }
            
        }

        if (Line2enemies.Count > 0)
        {
			foreach (var enemy in Line2enemies)
			{
                UiManager.instance.SetReadyEnemyLine2(enemy.GetProfile());//, enemy.GetAnimator());
			}
		}

        if (Line3enemies.Count > 0)
        {
			foreach (var enemy in Line3enemies)
			{
                UiManager.instance.SetReadyEnemyLine3(enemy.GetProfile());//, enemy.GetAnimator());
			}
		}
    }
}
