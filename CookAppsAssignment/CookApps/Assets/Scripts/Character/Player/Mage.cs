using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
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
		target.GetDamage(Atk * 5);
	}
}