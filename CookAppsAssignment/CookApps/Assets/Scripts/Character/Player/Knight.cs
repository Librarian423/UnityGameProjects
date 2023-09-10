using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
	private int hashActiveTrigger = Animator.StringToHash("ActiveTrigger");

	private Transform targetLocation;
	private bool isDashing = false;

	// Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
	}

	public override void ActiveSkill()
	{
		float longestDistance = 0f;

		if (side == Side.Player)
		{
			//search closest enemy
			foreach (var enemy in BattleManager.instance.enemies)
			{
				if (!enemy.gameObject.activeSelf)
				{
					continue;
				}

				float distance = Vector3.Distance(transform.position, enemy.transform.position);
				if (distance > longestDistance)
				{
					longestDistance = distance;
					target = enemy;
				}

			}
		}
		animator.SetTrigger(hashActiveTrigger);
	}

	public void StartDash()
	{
		if (target.transform.position.x > transform.position.x)
		{
			transform.position = target.transform.position + new Vector3(-1, 0, 0);
		}
		else
		{
			transform.position = target.transform.position + new Vector3(1, 0, 0);
		}
		target.GetDamage(Atk * 2);
	}
}
