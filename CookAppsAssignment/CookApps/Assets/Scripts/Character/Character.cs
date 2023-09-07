using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OldMan;
using static Wolf;

public class Character : MonoBehaviour
{
    //Side
    public enum Side
    {
        Player,
        Enemy,
    }
    [Header("Side")]
    public Side side;

    //state
    public enum State
    {
        Idle,
        Moving,
        Attack,
        Stun,
        Die,
    }

    [Header("State")]
    public State state;

    //Position
    [Header("Position")]
    [SerializeField] private Stats.Position position;

    //timer
    private float timer;

    //Components
    protected Animator animator;
    protected Collider collider;
    protected Rigidbody2D rigidbody;
    protected SpriteRenderer sprite;

    //Animation
    protected int hashIsMoving = Animator.StringToHash("IsMoving");
    protected int hashIsAttacking = Animator.StringToHash("IsAttacking");
    protected int hashDeathTrigger = Animator.StringToHash("DeathTrigger");

    [SerializeField] protected Stats stats;
    public Character target;

    //Max Stats Property
    [Header("Max Stats")]
    private float maxHp;
    public float MaxHp
    {
        get => maxHp;
        set
        {
            maxHp = value;
        }
    }

    private float maxAtk;
    public float MaxAtk
    {
        get => maxAtk;
        set
        {
            maxAtk = value;
        }
    }

    private float maxDef;
    public float MaxDef
    {
        get => maxDef;
        set
        {
            maxDef = value;
        }
    }

    private float maxAttackRange;
    public float MaxAttackRange
    {
        get => maxAttackRange;
        set
        {
            maxAttackRange = value;
        }
    }

    private float maxMoveSpeed;
    public float MaxMoveSpeed
    {
        get => maxMoveSpeed;
        set
        {
            maxMoveSpeed = value;
        }
    }

    private float maxattackSpeed;
    public float MaxattackSpeed
    {
        get => maxattackSpeed;
        set
        {
            maxattackSpeed = value;
        }
    }
    ///////////////////////////////////

    //Current Stats Property
    [Header("Current Stats")]
    [SerializeField] private float hp;
    public float Hp
    {
        get => hp;
        set
        {
            hp += value;
            if (hp > MaxHp)
            {
                hp = MaxHp;
            }
            else if (hp <= 0)
            {
                hp = 0;
                SetDeath();
            }
        }
    }

    [SerializeField] private float atk;
    public float Atk
    {
        get => atk;
        set
        {
            atk += value;
        }
    }

    [SerializeField] private float def;
    public float Def
    {
        get => def;
        set
        {
            def += value;
        }
    }

    [SerializeField] private float attackRange;
    public float AttackRange
    {
        get => attackRange;
        set
        {
            attackRange += value;
        }
    }

    [SerializeField] private float moveSpeed;
    public float MoveSpeed
    {
        get => moveSpeed;
        set
        {
            moveSpeed += value;
        }
    }

    [SerializeField] private float attackSpeed;
    public float AttackSpeed
    {
        get => attackSpeed;
        set
        {
            attackSpeed += value;
        }
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        InitStats();

        state = State.Idle;
        timer = AttackSpeed;
    }

    // Update is called once per frame
    protected virtual void Update()
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
            case State.Idle:
                //if battle start change//
                if (side == Side.Player)
                {
                    if (BattleManager.instance.GetIsEnemyAlive())
                    {
                        SetMoving();
                    }
                }
                else
                {
                    if (BattleManager.instance.GetIsPlayerAlive())
                    {
                        SetMoving();
                    }
                }                
                break;
            case State.Moving:
                if (AttackRange < Vector3.Distance(transform.position, target.transform.position))
                {
                    Vector3 direction = (target.transform.position - transform.position).normalized;
                    //Move
                    rigidbody.velocity = direction * MoveSpeed;

                    //rotation
                    sprite.flipX = transform.position.x > target.transform.position.x;
                }
                else
                {
                    rigidbody.velocity = Vector3.zero;
                    SetAttack();
                    break;
                }
                break;
            case State.Attack:
                if (timer >= AttackSpeed)
                {
                    animator.SetBool(hashIsAttacking, true);
                }
                if (AttackRange < Vector3.Distance(transform.position, target.transform.position))
                {
                    SetIdle();
                }
                break;
            case State.Stun:
                break;
            case State.Die:
                animator.SetTrigger(hashDeathTrigger);
                break;
        }
    }

    protected virtual void InitStats()
    {
        MaxHp = stats.hp;
        Hp = MaxHp;

        MaxAtk = stats.atk;
        Atk = MaxAtk;

        MaxDef = stats.def;
        Def = MaxDef;

        MaxAttackRange = stats.attackRange;
        attackRange = MaxAttackRange;

        MaxMoveSpeed = stats.moveSpeed;
        MoveSpeed = MaxMoveSpeed;

        MaxattackSpeed = stats.attackSpeed;
        AttackSpeed = MaxattackSpeed;

        position = stats.position;
    }

    public void SetTarget()
    {
        float shortestDistance = Mathf.Infinity;

        if (side == Side.Player)
        {
            //search closest enemy
            foreach (var enemy in BattleManager.instance.enemies)
            {
                if (!enemy.gameObject.activeSelf)
                {
                    continue;
                }

                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    target = enemy;
                }

            }
        }
        else
        {
            //search closest player
            foreach (var player in BattleManager.instance.players)
            {
                if (!player.gameObject.activeSelf)
                {
                    continue;
                }

                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    target = player;
                }

            }
        }       
    }

    public void SetIdle()
    {
        state = State.Idle;
        animator.SetBool(hashIsMoving, false);
        animator.SetBool(hashIsAttacking, false);
    }

    public void SetMoving()
    {
        state = State.Moving;
        animator.SetBool(hashIsMoving, true);
    }

    public void SetAttack()
    {
        state = State.Attack;
        animator.SetBool(hashIsMoving, false);
    }

    protected virtual void Attack()
    {
        target.GetDamage(Atk);
        timer = 0f;
        animator.SetBool(hashIsAttacking, false);
    }

    public void GetDamage(float damage)
    {
        //damage calcultaion
        float totalDamage = damage - Def;

        if (totalDamage < 0)
        {
            totalDamage = 0f;
        }
        //give damage
        Hp = -totalDamage;
    }

    public void SetDeath()
    {
        state = State.Die;        
    }

    public void SetUnenable()
    {
        gameObject.SetActive(false);
        BattleManager.instance.RemoveFromList(gameObject, side);
    }

    public Stats.Position GetPosition()
    {
        return position;
    }

    protected virtual void PassiveSkill() { }
    public virtual void ActiveSkill() { }
}
