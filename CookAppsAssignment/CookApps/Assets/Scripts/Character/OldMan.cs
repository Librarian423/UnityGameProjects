using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    //timer
    private float timer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        base.InitStats();
        state = PlayerState.Idle;
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
                    float angle;
                    if (transform.position.x > target.transform.position.x)
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
                if (timer >= AttackSpeed)
                {
					animator.SetBool(hashIsAttacking, true);
				}
				if (AttackRange < Vector3.Distance(transform.position, target.transform.position))
                {
                    SetIdle();
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
		animator.SetBool(hashIsMoving, false);
	}

    protected override void Attack()
    {
        base.Attack();
        timer = 0f;
		animator.SetBool(hashIsAttacking, false);
	}
}
