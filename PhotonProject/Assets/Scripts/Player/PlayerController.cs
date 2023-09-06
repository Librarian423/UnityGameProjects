using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components
    private new Rigidbody rigidbody;
    private Player player;
    private Ability ability;

    //Inputs
    private float horizontalInput;
    private float vertivalInput;

    //Timer
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();       
        player = GetComponent<Player>();
        ability = GetComponent<Ability>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        horizontalInput = Input.GetAxisRaw("Horizontal");
        vertivalInput = Input.GetAxisRaw("Vertical");

        //Inputs
        Vector3 inputDir = new Vector3(horizontalInput, 0, vertivalInput).normalized;

        if (player.IsMovable)
        {
            //Movement
            rigidbody.velocity = inputDir * player.moveSpeed;
            transform.LookAt(transform.position + inputDir);

            //Normal Attack
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.Attack();
                ability.NormalAbility();
            }

            //Special Attack
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.Attack();
                ability.SpecialAbility();
            }
        }
        //Movig Animation
        player.PlayerMoving(inputDir != Vector3.zero);

        //Rolling
        if (player.IsRollable && Input.GetKeyDown(KeyCode.Space) && timer >= ability.stats.coolTime) 
        {
            player.PlayerRolling();
            
        }       
    }

    private void Rolling()
    {       
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.forward * player.rollingDistance, ForceMode.Force);
    }

    private void EndRolling()
    {        
        timer = 0f;
    }
}
