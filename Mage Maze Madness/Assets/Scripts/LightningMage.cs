﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMage : BaseMage
{
    private ThirdPersonMovement control;

    //a bool to ensure the player using the script is the right type of mage to use the lightning ability
    public bool isLightningMage = false;

    //a bool to act as a switch to turn on the timer. 
    private bool timerStart;

    //a bool to know if the player has the energy to use an ability 
    public bool hasOrb;


    private float speedMultiplyer = 2.0f;
    private float speedtimer = 5.0f;
    private float controlSpeed;

    //this allows the player to change color to match their mage
    public Material[] lightningC = new Material[6];
    Material[] mats;



    void Start()
    {
        control = this.GetComponent<ThirdPersonMovement>();
        //controlSpeed = control.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //if a player is a Fire Mage they get the Lightning Mage Robes and "LightningMage" tag.
        if (isLightningMage == true)
        {
            lightningRobes();
            Player.tag = "LightningMage";

            //If the player has an energy orb they can use their ability.
            if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
            {
                control.speed = controlSpeed * speedMultiplyer;
                hasOrb = false;
            }

            if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
            {
                Debug.Log("You need to collect and energy orb to use an ability.");
            }

        }

        //the timer for how long the mage is speed up for.
        if (timerStart == true)
        {
            if (speedtimer > 0)
            {
                speedtimer -= Time.deltaTime;
            }
            else if (speedtimer <= 0)
            {
                timerStart = false;
                speedtimer = 5.0f;
                control.speed = controlSpeed;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLightningMage == true)
        {
            //If the mage collides with the Hunter, they become the hunter with a brief no tagback delay.
            if (other.gameObject.tag == "Hunter")
            {
                Player.GetComponent<LightningMage>().isLightningMage = false;
                Invoke("BecomeHunter", 1.0f);

            }
        }
    }

    void BecomeHunter()
    {
        Player.GetComponent<theHunter>().isTheHunter = true;

    }


    void lightningRobes()
    {
        mats = Player.GetComponent<MeshRenderer>().materials;
        mats[0] = lightningC[0];
        mats[1] = lightningC[1];
        mats[2] = lightningC[2];
        mats[3] = lightningC[3];
        mats[4] = lightningC[4];
        mats[5] = lightningC[5];
        Player.GetComponent<MeshRenderer>().materials = mats;

    }

}
