using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : Player
{
    public enum PlayerState
    {
        Idle,
        Moving,
        Attack,
        Stun,
        Die,
    }

    public PlayerState state;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        base.InitStats();
        state = PlayerState.Idle;
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
            case PlayerState.Idle:
                //if battle start change//               
                if (BattleManager.instance.GetIsEnemyAlive())
                {
                    SetMoving();
                }
                
                break;
            case PlayerState.Moving:

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
            case PlayerState.Attack:
                if (true)
                {

                }
                break;
            case PlayerState.Stun:
                break;
            case PlayerState.Die:            
                break;
        }
    }

    public void SetIdle()
    {
        state = PlayerState.Idle;
        animator.SetBool(hashIsMoving, false);
        animator.SetBool(hashIsAttacking, false);
    }

    public void SetMoving()
    {
        state = PlayerState.Moving;
        animator.SetBool(hashIsMoving, true);
    }

    public void SetAttack()
    {
        state = PlayerState.Attack;
        animator.SetBool(hashIsAttacking, true);
    }
}
