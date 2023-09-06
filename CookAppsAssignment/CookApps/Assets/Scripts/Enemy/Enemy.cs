using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Components
    protected Animator animator;
    protected Collider collider;
    protected Rigidbody2D rigidbody;

    //Animation
    protected int hashIsMoving = Animator.StringToHash("IsMoving");
    protected int hashIsAttacking = Animator.StringToHash("IsAttacking");
    //protected int hashRollingTrigger = Animator.StringToHash("RollingTrigger");

    [SerializeField] protected Stats stats;
    public Player target;

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
            else if (hp < 0)
            {
                hp = 0;
                Die();
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

        InitStats();   
    }

    // Update is called once per frame
    protected virtual void Update() { }

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
    }

    public void SetTarget()
    {
        float shortestDistance = Mathf.Infinity;

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

    public void EnemyGetDamage(float damage)
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

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }

    protected virtual void PassiveSkill() { }
    protected virtual void ActiveSkill() { }
}
