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
    }

    public PlayerState state;

    //Animation
    private Animator animator;
    private int hashIsMoving = Animator.StringToHash("IsMoving");
    private int hashIsNormalAttack = Animator.StringToHash("IsNormalAttack");
    private int hashRollingTrigger = Animator.StringToHash("RollingTrigger");

    //Colliders
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Collider hitCollider;

    //States
    public bool IsMovable = true;
    public bool IsRollable = true;


    [Header("Stats")]
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

    public void EndAttack()
    {
        animator.SetBool(hashIsNormalAttack, false);
        PlayerIdle();
    }
    ///////////////////////////
    

}
