using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 1000;
    public Transform firingPoint;
    public LayerMask layerMask;
    public LineRenderer laser;

    public float pickUpDistance = 3;
    public bool hasBall;

    public List<Transform> balls;

    public Color defaultColor, holdingColor;

    private void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject go in temp)
        {
            balls.Add(go.transform);
        }
    }

    void Update()
    {
        //Firing and grabbing ball object
        if (Input.GetButtonDown("Fire1"))
        {
            if (hasBall)
            {
                projectile.GetComponent<Rigidbody>().isKinematic = false;
                projectile.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);
                hasBall = false;
                projectile.transform.SetParent(null);
                projectile.GetComponent<Renderer>().material.color = defaultColor;
            }
            else
            {
                if (Vector3.Distance(transform.position, GetClosestBall(balls).position) < pickUpDistance)
                {
                    hasBall = true;
                    projectile = GetClosestBall(balls).gameObject;
                    projectile.transform.position = transform.position;
                    projectile.transform.SetParent(this.transform);
                    projectile.GetComponent<Rigidbody>().isKinematic = true;
                    projectile.GetComponent<Renderer>().material.color = holdingColor;
                }
            }

        }
    }

    //This is to grab the closest ball to the player
    Transform GetClosestBall(List<Transform> _balls)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in _balls)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
