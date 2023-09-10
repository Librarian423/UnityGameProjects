using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    private void OnEnable()
    {
        UiManager.instance.SetStageNameText(title);
    }
}
