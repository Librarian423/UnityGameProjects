using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : Player
{
    public enum PlayerState
    {
        Idle,
        Moving,
        Attack,
        Stun,
        Die,
    }

    public PlayerState state;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        base.InitStats();
        state = PlayerState.Idle;
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
