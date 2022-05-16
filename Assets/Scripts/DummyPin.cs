using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPin : MonoBehaviour
{
    // Wobbly Pin just for fun

    bool knockedOver = false;
    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //A pin is only considered knocked over if its halfway passed its rotation
        if (transform.up.y < 0.5f && !knockedOver)
        {
            //playerController.PinFall();
            knockedOver = true;
        }
    }
}
