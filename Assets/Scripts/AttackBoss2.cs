using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss2 : Attack
{
    public Transform [] firePoints;
    public Transform [] firePointsStrong;
    public Transform [] laserPointsStrong;
    public GameObject shootPrefStrong;
    [SerializeField]
    public GameObject[] laserPref;
    protected float attackRateStrong = 2.5F;
    protected float innerAttackRateStrong = 0;
    protected float attackRateLaser = 4F;
    protected float innerAttackRateLaser = 0 ;
    void Update()
    {
        if (innerAttackRate > attacRate)
        {   
            foreach (Transform t in firePoints) {

                GameObject shoot = Instantiate(shootPref, t.position, Quaternion.identity);

            }
     
            innerAttackRate = 0;
            FindAnyObjectByType<AudioManager>().Play(attackName);

        }



        if (innerAttackRateStrong > attackRateStrong)
        {
            foreach (Transform t in firePointsStrong)
            {

                GameObject shoot = Instantiate(shootPrefStrong, t.position, Quaternion.identity);

            }

            innerAttackRateStrong = 0;
            FindAnyObjectByType<AudioManager>().Play("AlienLaser2");

        }


        if (innerAttackRateLaser > attackRateLaser)
        {   int i=0;
            foreach (Transform t in laserPointsStrong)
            {
                
                GameObject shoot = Instantiate(laserPref[i], t.position, Quaternion.identity);            
                shoot.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("red");  
                i++;

            }
           if (innerAttackRateLaser > attackRateLaser+2) { innerAttackRateLaser = 0; }

            FindAnyObjectByType<AudioManager>().Play("AlienLaser3");

        }


        float myTimer = Time.deltaTime;

        innerAttackRateLaser += myTimer;
        innerAttackRate += myTimer;
        innerAttackRateStrong += myTimer;




    }
}


