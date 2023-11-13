using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss5 : Attack
{
    public Transform[] firePoints;
    private float attackRateLaser = 1F;
    private float innerAttackRateLaser = 0F;
    public GameObject laserPref;

    public void Update()
    {
        if (innerAttackRateLaser > (attackRateLaser + attacRate))
        {
            
            foreach (Transform t in firePoints)
            {

                GameObject shoot = Instantiate(laserPref, t.position, Quaternion.identity);
               

            }
            if (innerAttackRateLaser > attackRateLaser+0.05) { innerAttackRateLaser = 0; }

            FindAnyObjectByType<AudioManager>().Play("AlienLaser3");

        }

        float myTimer = Time.deltaTime;

        innerAttackRateLaser += myTimer;
        innerAttackRate += myTimer;

    }

}


