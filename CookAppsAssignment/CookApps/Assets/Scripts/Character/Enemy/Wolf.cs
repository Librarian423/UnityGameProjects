using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Character
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log(side);
		
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void InitRotation()
    {
		if (side == Side.Enemy)
		{
			Debug.Log("Flip");
			sprite.flipX = true;
		}
	}
}
