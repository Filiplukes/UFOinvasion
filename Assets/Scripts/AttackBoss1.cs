using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss1 : Attack
{
    public Transform [] firePoints;
    public Transform [] firePointsStrong;
    public Transform [] laserPointsStrong;
    public GameObject shootPrefStrong;
    [SerializeField]
    public GameObject[] laserPref;
    private float attackRateStrong = 1.75F;
    private float innerAttackRateStrong = 0;
    private float attackRateLaser = 4F;
    private float innerAttackRateLaser = 3F ;
    void Update()
    {
        if (innerAttackRate > attacRate)
        {   
            foreach (Transform t in firePoints) {

                GameObject shoot = Instantiate(shootPref, t.position, Quaternion.identity);

            }
     
            innerAttackRate = 0;
            FindFirstObjectByType<AudioManager>().Play(attackName);

        }



        if (innerAttackRateStrong > attackRateStrong)
        {
            foreach (Transform t in firePointsStrong)
            {

                GameObject shoot = Instantiate(shootPrefStrong, t.position, Quaternion.identity);

            }

            innerAttackRateStrong = 0;
            FindFirstObjectByType<AudioManager>().Play("AlienLaser2");

        }


        if (innerAttackRateLaser > attackRateLaser)
        {   int i=0;
            foreach (Transform t in laserPointsStrong)
            {
                
                GameObject shoot = Instantiate(laserPref[i], t.position, Quaternion.identity);
                i++;

            }
           if (innerAttackRateLaser > attackRateLaser+2) { innerAttackRateLaser = 0; }

            FindFirstObjectByType<AudioManager>().Play("AlienLaser3");

        }


        float myTimer = Time.deltaTime;

        innerAttackRateLaser += myTimer;
        innerAttackRate += myTimer;
        innerAttackRateStrong += myTimer;




    }
}


