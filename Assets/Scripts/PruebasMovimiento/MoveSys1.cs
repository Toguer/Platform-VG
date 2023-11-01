using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class MoveSys1 : MonoBehaviour
{
    
    [SerializeField]private bool facingRight = false;
    private MoveBehaviour _moveBehaviour;
    private DamageBehaviourEnemy enemyLife;

    

    void Start()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        enemyLife = GetComponent<DamageBehaviourEnemy>();
    }

    void Update()
    {
        if (facingRight)
        {
            _moveBehaviour.moveHorizontal(_moveBehaviour.Velocity);
        }
        else
        {
            _moveBehaviour.moveHorizontal(-_moveBehaviour.Velocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enemyLife.DetectFalseWalls)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Flip();
            }
        }

        if (other.gameObject.TryGetComponent(out playerMovement pj)) //No entra en trigger con el padre del body por la configuración de las fisicas
        {
            //Flip();
            Debug.Log("Collision en MoveSys1");

        }
    }


    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, -180, 0));
    }

}