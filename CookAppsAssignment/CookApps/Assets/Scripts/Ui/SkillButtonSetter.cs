using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonSetter : MonoBehaviour
{
	private RectTransform SkillButtons;

    private float size = 100f;

    private void Awake()
    {
		SkillButtons = GetComponent<RectTransform>();
		UiManager.instance.SetSkillButtons(gameObject);
	}
    

    public void SetSize(int count)
    {
        SkillButtons.sizeDelta = new Vector2(count * size, size);
    }
}
