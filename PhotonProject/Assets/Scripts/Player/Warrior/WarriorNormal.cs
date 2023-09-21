using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorNormal : MonoBehaviour
{
    [SerializeField] private float stunTime = 0.5f;
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            other.GetComponentInParent<Player>().GetDamage(damage);
            Debug.Log(other.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            other.GetComponentInParent<Player>().PlayerStun(stunTime);
        }
    }
}
