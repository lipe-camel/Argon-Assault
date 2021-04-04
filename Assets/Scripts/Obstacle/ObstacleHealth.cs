﻿using System;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] [Tooltip("The value to be multiplied by the obstacle randomized size")]
    float healthBaseValue = 10f;

    //STATS
    float health;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;


    internal void CustomStart()

    {
        obstacle = GetComponent<Obstacle>();
        health = healthBaseValue * obstacle.obstacleRandomness.rndmSize;
    }

    internal void ManageDamage(float damage)
    {
        health -= damage;
        if(health >= 0)
        {
            LoseHealth();
        }
        else
        {
            Die();
        }
    }

    private void LoseHealth()
    {
        obstacle.obstacleFX.PlayDamageVFX(transform.position); //TODO check the transform
    }

    private void Die()
    {
        obstacle.obstacleFX.PlayDeathVFX(transform.position); //TODO check the transform
        Destroy(gameObject);
    }
}