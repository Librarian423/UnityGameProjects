using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OldMan;

public class Wolf : Enemy
{
    public enum EnemyState
    {
        Idle,
        Moving,
        Attack,
        Stun,
        Die,
    }

    public EnemyState state;

    //timer
    private float timer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        state = EnemyState.Idle;
        timer = AttackSpeed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        timer += Time.deltaTime;

        //Set Target
        if (target == null || !target.gameObject.activeSelf)
        {
            SetTarget();
            SetIdle();
        }

        switch (state)
        {
            case EnemyState.Idle:
                //if battle start change//               
                if (BattleManager.instance.GetIsPlayerAlive())
                {
                    SetMoving();
                }
                break;
            case EnemyState.Moving:
                if (AttackRange < Vector3.Distance(transform.position, target.transform.position))
                {
                    Vector3 direction = (target.transform.position - transform.position).normalized;
                    //Move
                    rigidbody.velocity = direction * MoveSpeed;

					//rotation
					float angle;
					if (transform.position.x > target.transform.position.x)
					{
						angle = 0f;
					}
					else
					{
						angle = 180f;
					}

					transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
				}
                else
                {
                    rigidbody.velocity = Vector3.zero;
                    SetAttack();
                    break;
                }
                break;
            case EnemyState.Attack:
				if (timer >= AttackSpeed)
				{
					animator.SetBool(hashIsAttacking, true);
				}
				if (AttackRange < Vector3.Distance(transform.position, target.transform.position))
				{
					SetIdle();
				}
				break;
            case EnemyState.Stun:
                break;
            case EnemyState.Die:
                animator.SetTrigger(hashDeathTrigger);
                break;
        }
    }

    public void SetIdle()
    {
        state = EnemyState.Idle;
        animator.SetBool(hashIsMoving, false);
        animator.SetBool(hashIsAttacking, false);
    }

    public void SetMoving()
    {
        state = EnemyState.Moving;
        animator.SetBool(hashIsMoving, true);
    }

    public void SetAttack()
    {
        state = EnemyState.Attack;
        animator.SetBool(hashIsMoving, false);
    }

	protected override void Attack()
	{
		base.Attack();
		timer = 0f;
		animator.SetBool(hashIsAttacking, false);
	}

	public void SetDeath()
    {
        state = EnemyState.Die;
    }

    public override void Die()
    {
        SetDeath();
    }
}
