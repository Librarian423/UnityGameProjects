using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        state = EnemyState.Idle;
    }

    // Update is called once per frame
    protected override void Update()
    {
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
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    if (angle > 90f && angle < 270f)
                    {
                        angle = 180f;
                    }
                    else
                    {
                        angle = 0f;
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
                if (true)
                {

                }
                break;
            case EnemyState.Stun:
                break;
            case EnemyState.Die:
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
        animator.SetBool(hashIsAttacking, true);
    }

    public void SetDeath()
    {
        state = EnemyState.Die;
        Debug.Log("death");
    }

    public override void Die()
    {
        base.Die();
        SetDeath();
    }
}
