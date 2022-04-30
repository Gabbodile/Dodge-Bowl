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
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Debug.Log("running");
        Vector3 moveToPos = GetRandomPosition();
        agent.SetDestination(moveToPos);
        while (Vector3.Distance(transform.position, moveToPos) < 0.1f)
        {
            /*transform.position = Vector3.MoveTowards(transform.position, moveToPos, Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(moveToPos);*/
            yield return null;
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(Move());
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
