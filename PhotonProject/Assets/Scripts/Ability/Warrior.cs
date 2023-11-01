using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Ability
{
    //Colliders
    [SerializeField] private Collider dashCollider;
    [SerializeField] private Collider spinCollider;

    //Components
    private new Rigidbody rigidbody;
    private PlayerController controller;
    private Player player;

    //variables
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashTime = 1.5f;
    [SerializeField] private float spinTime = 3f;

    //bools
    private bool isDash = false;
    private bool isSpin = false;

    //timer
    private float timer = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
        player = GetComponent<Player>();

        dashCollider.enabled = false;
        spinCollider.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isDash)
        {
            Dash();
        }
        if (isSpin)
        {
            Spin();
        }
        
    }

    private void Dash()
    {
        if (timer >= dashTime)
        {
            isDash = false;
            player.IsMovable = true;
            player.IsRollable = true;
            player.EndAttack();

            dashCollider.enabled = false;
        }
        timer += Time.deltaTime;
        rigidbody.velocity = transform.forward * dashSpeed;
    }

    private void Spin()
    {
        if (timer >= spinTime)
        {
            isSpin = false;
            player.IsRollable = true;
            player.EndAttack();

            spinCollider.enabled = false;   
        }
        timer += Time.deltaTime;
    }

    public override void NormalAbility()
    {
        dashCollider.enabled = true;

        player.IsMovable = false;
        player.IsRollable = false;
        player.NormalAttack();
        
        isDash = true;
        timer = 0f;
    }

    public override void SpecialAbility()
    {
        spinCollider.enabled = true;

        player.IsRollable = false;
        player.SpecialAttack();
        isSpin = true;
        timer = 0f;
    }
}