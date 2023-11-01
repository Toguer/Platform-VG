using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private DoorState _ds;
    private CircleCollider2D _cc;
    [SerializeField] private Sprite buttonPressed;

    void Start()
    {
        _cc = GetComponent<CircleCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _ds.OpenDoor();
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
        }
    }
}
