using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable/Stats")]
public class Stats : ScriptableObject
{
    public float hp;
    public float atk;
    public float def;
    public float attackRange;
    public float moveSpeed;
    public float attackSpeed;
}