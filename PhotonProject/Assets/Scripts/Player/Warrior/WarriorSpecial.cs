using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpecial : MonoBehaviour
{
    private Collider collider;

    [SerializeField] float attackSpeed = 1f;
    [SerializeField] float damage = 2f;

    private float timer = 0f;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (collider.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (timer <= 0f && other.gameObject.CompareTag("HitBox"))
        {
            timer = attackSpeed;
            other.GetComponentInParent<Player>().GetDamage(damage);
        }
    }
}
