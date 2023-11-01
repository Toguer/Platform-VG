using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Boosts
{
    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.TryGetComponent<PrincessMovement>(out PrincessMovement pj))
        {
            other.gameObject.GetComponent<MoveBehaviour>().Velocity = 6;
        }
        
            
    }
}