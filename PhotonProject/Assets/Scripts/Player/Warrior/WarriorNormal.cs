using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorNormal : MonoBehaviour
{
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            Debug.Log(other.name);
            count++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        
    }
}
