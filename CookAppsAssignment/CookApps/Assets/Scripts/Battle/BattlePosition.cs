using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePosition : MonoBehaviour
{
    [SerializeField] private GameObject pos;

    public GameObject playerLine1;
    public GameObject playerLine2; 
    public GameObject playerLine3; 

    public GameObject EnemyLine1; 
    public GameObject EnemyLine2; 
    public GameObject EnemyLine3;

    public Vector3 SetPlayerPosition(int index)
    {
        GameObject temp;

        if (index < 3)
        {
            temp = Instantiate(pos, playerLine1.transform);

            return Camera.main.ScreenToWorldPoint(temp.transform.position);
        }

        if (index < 6) 
        {
            temp = Instantiate(pos, playerLine2.transform);
            return temp.transform.position;
        }
        temp = Instantiate(pos, playerLine3.transform);
        return temp.transform.position;
    }
}