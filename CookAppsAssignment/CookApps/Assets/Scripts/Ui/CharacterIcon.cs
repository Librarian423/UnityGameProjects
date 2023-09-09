using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIcon : MonoBehaviour
{
    private Animator animator;
    private Image image;
    private SpriteRenderer sprite;
    private int id;

    private bool isPlayer;

    private void Awake()
    {
		animator = GetComponent<Animator>();
        image = GetComponent<Image>();
		sprite = GetComponent<SpriteRenderer>();
	}

    public void SetImageSprite(Sprite sprite)
    {
        image.sprite = sprite;
        this.sprite.sprite = sprite;
    }

    public void SetAnimator(RuntimeAnimatorController animator)
    {
		this.animator.runtimeAnimatorController = animator;
    }

    public void SetIsPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;
    }

    public bool GetIsPlayer()
    {
        return isPlayer;
    }

    public void SetId(int num)
    {
        id = num;
    }

    public int GetId()
    {
        return id;
    }
}