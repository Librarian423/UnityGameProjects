using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Character
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

    public override void InitRotation()
    {
        Debug.Log("wolf "+ sprite);

		if (side == Side.Enemy)
		{
			sprite.flipX = true;
		}
	}
}
