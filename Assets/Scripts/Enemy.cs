using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerState
{ 
    defence,
    offence 
}

//The IEunumerator wasn't working properly and could not figure out why it wasn't working as per normal. 
public class Enemy : MonoBehaviour
{
    public float minZ = 0, maxZ = 5, minX = -5, maxX = 5;
    public int myHealth = 5;
    bool isDead = false;
    NavMeshAgent agent;
    private object projectile;

    public PlayerState playerState; 

    private void Start()
    {   
        //Random movement in the set coordinates
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Move());

        //PlayerState
        playerState = global::PlayerState.defence;
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

    /*public IEumerator to see if the enemy is on an Offensive or Defensive state. 
    void PlayerState()
    {
        switch (playerState)
        {
            case PlayerState.defence:
                StartCoroutine(Move());
                break;

            case PlayerState.offence:
                
                break;
        }
    }*/

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

        /*if (playerState = PlayerState.offence)
        {
            return;
        }*/
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }

     
    //Velocity and Position of ball
    /*private void Update()
    {

        if (GameObject.Find("BowlingBall").transform.position = Vector3.(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)))
        {
            if (GameObject.Find("BowlingBall").GetComponent<Rigidbody>().velocity.magnitude < 1)
            {
                playerState = PlayerState.offence;
            }
            else
            {
                playerState = PlayerState.defence;
            }
        }
    }*/
}
