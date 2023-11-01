using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStunned : DamageBehaviourPlayer
{
    public override void Apply()
    {
        _player.Flip();
        stunCounter = stunTime;
    }

    
}