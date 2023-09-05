using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Ability
{
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void NormalAbility()
    {
        Debug.Log("normal");
    }

    public override void SpecialAbility()
    {
        Debug.Log("special");
    }
}
