﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDMG : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<playerMovement>(out playerMovement pj))
        {
            GameOverFall._gameOverFall.GameOver();
        }
    }
}
