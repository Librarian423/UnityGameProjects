using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable/Stats")]
public class Stats : ScriptableObject
{
    public float hp = 100f;
    public float atk = 10f;
    public float def = 0;
    public float attackSpeed = 1f;
    public float coolTime = 2f;
}
