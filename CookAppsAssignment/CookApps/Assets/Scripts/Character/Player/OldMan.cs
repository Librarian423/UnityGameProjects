using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OldMan : Character
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
        var effect = Instantiate(skillEffect);
        effect.transform.position = transform.position;
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
