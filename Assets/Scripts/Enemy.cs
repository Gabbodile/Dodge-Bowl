using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum playerState
{
    defence,
    offence
}
public class Enemy : MonoBehaviour
{
    public float minZ = 0, maxZ = 5, minX = -5, maxX = 5;
    public int myHealth = 5;
    bool isDead = false;
    NavMeshAgent agent;
    private object projectile;

    private void Start()
    {   
        //Random movement in the set coordinates
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

        if (playerState offence)
        {
            return;
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }

    //public IEumerator to see if the enemy is on an Offensive or Defensive state. 
    public IEnumerator PlayerState()
    {
        switch(state)
        {
            case playerState defence:
                StartCoroutine(Move());
                break;

            case playerState offence:
                //move to ball
                //Are we close to ball?
                //Pick up ball
                //throw at player
                break;
        }
    }

    //Velocity and Position of ball
    private void Update()
    {
        
        if (GameObject.Find("BowlingBall").transform.position = Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)))
        {
            if (GameObject.Find("BowlingBall").GetComponent<Rigidbody>().velocity.magnitude < 1)
            {
                playerState offence;
            }
        }
        else
        {
            playerState defence;
        }
    }
}
