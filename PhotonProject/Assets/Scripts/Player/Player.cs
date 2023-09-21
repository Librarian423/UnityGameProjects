using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Moving,
        Rolling,
        Attacking,
        Stun,
    }

    public PlayerState state;

    //Animation
    private Animator animator;
    private int hashIsMoving = Animator.StringToHash("IsMoving");
    private int hashIsNormalAttack = Animator.StringToHash("IsNormalAttack");
    private int hashIsSpecialAttack = Animator.StringToHash("IsSpecialAttack");
    private int hashRollingTrigger = Animator.StringToHash("RollingTrigger");

    //Colliders
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Collider hitCollider;

    //States
    public bool IsMovable = true;
    public bool IsRollable = true;

    //timer
    private float timer = 0f;
    private float stunTime;

    [Header("Stats")]
    [SerializeField] private float hp = 100f;
    public float moveSpeed = 10f;
    private float originMoveSpeed;
    public float rollingDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        originMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case PlayerState.Idle:
                IsMovable = true;
                break;
            case PlayerState.Moving:

                break;
            case PlayerState.Rolling:
                IsMovable = false;
                //moveSpeed = 0f;
                break;
            case PlayerState.Attacking:
                break;
            case PlayerState.Stun:              
                Stun();
                break;
        }
    }

    //Moving
    public void PlayerMoving(bool isMoving)
    {
        
        if (IsMovable)
        {
            if (!isMoving)
            {
                state = PlayerState.Idle;
            }
            else
            {
                state = PlayerState.Moving;
            }
            animator.SetBool(hashIsMoving, isMoving);
            
        }
        
    }
    ///////////////////////////
    
    //Rolling
    public void PlayerRolling()
    {
        if (state == PlayerState.Rolling)
        {
            return;
        }
        state = PlayerState.Rolling;
        animator.SetTrigger(hashRollingTrigger);
        hitCollider.enabled = false;
    }

    private void EndRolling()
    {
        moveSpeed = originMoveSpeed;
        PlayerIdle();
        hitCollider.enabled = true;
    }
    ///////////////////////////

    //Idle
    private void PlayerIdle()
    {
        state = PlayerState.Idle;
    }
    ///////////////////////////

    //Attack
    public void Attack()
    {
        state = PlayerState.Attacking;
    }

    public void NormalAttack()
    {

        animator.SetBool(hashIsNormalAttack, true);
    }

    public void SpecialAttack()
    {
        animator.SetBool(hashIsSpecialAttack, true);
    }

    public void EndAttack()
    {
        animator.SetBool(hashIsNormalAttack, false);
        animator.SetBool(hashIsSpecialAttack, false);
        PlayerIdle();
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
    }
    ///////////////////////////
    ///

    //Stun
    public void PlayerStun(float time)
    {
        state = PlayerState.Stun;
        IsMovable = false;
        timer = 0f;
        stunTime = time;
    }
    
    private void Stun()
    {
        timer += Time.deltaTime;
        if (timer > stunTime)
        {
            PlayerIdle();
        }
    }
}
