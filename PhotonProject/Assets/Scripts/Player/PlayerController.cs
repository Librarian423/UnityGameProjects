using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private GameObject gameObject;
    private new Rigidbody rigidbody;
    private Player player;
    

    //Inputs
    float horizontalInput;
    float vertivalInput;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //gameObject = GetComponent<GameObject>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        vertivalInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(horizontalInput, 0, vertivalInput).normalized;

        if (player.IsMovable)
        {
            

            rigidbody.velocity = inputDir * player.moveSpeed;

            transform.LookAt(transform.position + inputDir);

            
        }
        player.PlayerMoving(inputDir != Vector3.zero);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.PlayerRolling();
            
        }
    }

    void Rolling()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.forward * player.rollingDistance, ForceMode.Force);
    }
}

