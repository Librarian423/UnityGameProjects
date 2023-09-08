using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Scriptable/Stage")]
public class StageInfo : ScriptableObject
{
    public List<Character> Line1enemies;
    public List<Character> Line2enemies;
    public List<Character> Line3enemies;
}
