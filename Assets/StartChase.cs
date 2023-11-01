using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChase : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        boss.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("Levels");
        FindObjectOfType<AudioManager>().Play("Dungeon");
    }
}