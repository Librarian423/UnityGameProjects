using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character;
using UnityEngine.U2D;

public class Worm : Character
{
    private bool isSkillUsed = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (IsReady)
        {
            if (isSkillUsed)
            {
                ActiveSkill();
                isSkillUsed = false;
            }
        }
        base.Update();
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
        //find farthest player
        float longestDistance = 0f;

        if (side == Side.Enemy)
        {
            //search closest player
            foreach (var enemy in BattleManager.instance.players)
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

        //goto player
        if (target.transform.position.x > transform.position.x)
        {
            transform.position = target.transform.position + new Vector3(-1, 0, 0);
        }
        else
        {
            transform.position = target.transform.position + new Vector3(1, 0, 0);
        }
        var effect = Instantiate(skillEffect);
        effect.transform.position = transform.position;
    }
}
