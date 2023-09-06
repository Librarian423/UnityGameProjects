using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Components
    protected Animator animator;
    protected Collider collider;

    [SerializeField] protected Stats stats;
    public GameObject target;

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
    ///////////////////////////////////

    //Current Stats Property
    [Header("Current Stats")]
    [SerializeField] private float hp;
    public float Hp
    {
        get => hp;
        set
        {
            Debug.Log(value);
            hp += value;
            if (hp > MaxHp)
            {
                hp = MaxHp;
            }
            else if (hp < 0)
            {
                hp = 0;
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

    private float attackRange;
    public float AttackRange
    {
        get => attackRange;
        set
        {
            attackRange += value;
        }
    }

    public float moveSpeed;
    public float attackSpeed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
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

        AttackRange = stats.attackRange;
        //MaxHp = Hp;

        //Hp = stats.moveSpeed;
        //MaxHp = Hp;

       // Hp = stats.attackSpeed;
        //MaxHp = Hp;
    }

    protected virtual void PassiveSkill() { }
    protected virtual void ActiveSkill() { }
}
