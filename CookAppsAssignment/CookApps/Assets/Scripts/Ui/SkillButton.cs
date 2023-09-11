using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
	[SerializeField] private Button button;
    [SerializeField] private Slider coolSlider;
	[SerializeField] private TextMeshProUGUI coolText;
	[SerializeField] private Character character;
    [SerializeField] private float coolTime;

    //timer
    private float timer = 0f;

    private void Awake()
    {
		button = GetComponent<Button>();
	}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (coolSlider.value >= 0)
        {
            coolSlider.value = timer;
			coolText.text = ((int)timer).ToString();

		}
		if (timer <= 0f)
		{
			coolText.enabled = false;
			button.interactable = true;
		}
		if (character.gameObject.activeSelf == false)
		{
			gameObject.SetActive(false);
		}
	}

    public void SetButton(Character character)
    {
        this.character = character;
		coolTime = this.character.CoolTime;
        timer = coolTime;
		button.interactable = false;
        coolSlider.maxValue = coolTime;
		coolSlider.value = coolTime;
		coolText.text = coolTime.ToString();
	}

    public void OnClick()
    {
		if (timer <= 0f)
		{
			character.ActiveSkill();
			timer = coolTime;
			coolSlider.value = coolTime;
			button.interactable = false;
			coolText.enabled = true;
		}
	}
    
}
