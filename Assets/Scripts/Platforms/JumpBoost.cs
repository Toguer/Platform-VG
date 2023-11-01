using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : Boosts
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PrincessMovement>(out PrincessMovement pj))
        {
            pj.JumpVelocity = 11f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<GroundChecker>(out GroundChecker pj))
        {
            pj.InitialJumpVelocity = 5.5f;
        }
    }
}
