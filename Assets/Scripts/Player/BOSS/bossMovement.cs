using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : PrincessMovement
{
    #region propiedades y variables
    
    private float jumpTime;

    public float JumpTime => jumpTime;

    #endregion

    void Update()
    {
        base.Update();

        if (CommmandManager.checkCommand(chaseTime))
        {
            //Debug.Log(chaseTime+"Boss salta");
            if (isWalled)
            {
                Flip();
            }
            Jump();
            jumpTime = CommmandManager.jumpTime();
            Debug.Log("Boss salta durante"+jumpTime);
        }

        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }

        if (jumpTime <= 0 && _rb.velocity.y > 0)    //Funciona mejor si JumpTime >= , pero esta mal :(
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * .5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }
    
}