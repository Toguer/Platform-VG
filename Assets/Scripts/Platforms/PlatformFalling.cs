using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{

    private float fallDelay = 0.5f;
    private float respawn = 5f;
    private Vector3 start;

    public Rigidbody2D _rb;
    public BoxCollider2D _bc;

    private void Start()
    {
        start = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawn);
        }

    }

    void Fall()
    {
        _rb.isKinematic = false;
        _bc.isTrigger = true;
    }
    void Respawn()
    {
        transform.position = start;
        _rb.isKinematic = true;
        _rb.velocity = Vector3.zero;
        _bc.isTrigger = false;
    }

}
