using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float minZ = 0, maxZ = 5, minX = -5, maxX = 5;
    public int myHealth = 5;
    bool isDead = false;
    NavMeshAgent agent;

    private void Start()
    {
        while (isDead == false)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(GetRandomPosition());
        }
    }
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

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }
}
