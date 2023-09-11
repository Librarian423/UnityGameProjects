using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character;
using UnityEngine.U2D;

public class Skull : Character
{
    private float skillTimer = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        skillTimer = CoolTime;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (state == State.Attack)
        {
            skillTimer -= Time.deltaTime;
            if (skillTimer <= 0f)
            {
                ActiveSkill();
                skillTimer = CoolTime;
            }
        }
    }

    public override void InitRotation()
    {
        if (side == Side.Enemy)
        {
            sprite.flipX = true;
        }
    }

    public override void ActiveSkill()
    {
        var effect = Instantiate(skillEffect);
        effect.transform.position = transform.position;
        target.GetDamage(Atk * 1.5f);
    }
}
