using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int myHealth = 5;
    public float mySpeed;
    bool isDead = false;
    public void Hit(int _damage)
    {

        myHealth -= _damage;
        if (myHealth <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                GameEvents.ReportEnemyDied(this);
            }
        }
        else
        {
            GameEvents.ReportEnemyHit(this);
        }

    }
}
