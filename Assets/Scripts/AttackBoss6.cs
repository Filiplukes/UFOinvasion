using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss6 : Attack
{
    public Transform [] firePoints;
    public Transform [] firePointsStrong;
    public GameObject shootPrefStrong;
    [SerializeField]
    private float attackRateStrong = 1.9F;
    private float innerAttackRateStrong = 0;
    void Update()
    {
        if (innerAttackRate > attacRate)
        {   
            foreach (Transform t in firePoints) {

                Instantiate(shootPref, t.position, Quaternion.identity);

            }
     
            innerAttackRate = 0;
            FindAnyObjectByType<AudioManager>().Play(attackName);

        }



        if (innerAttackRateStrong > attackRateStrong)
        {
            foreach (Transform t in firePointsStrong)
            {

               Instantiate(shootPrefStrong, t.position, Quaternion.identity);

            }

            innerAttackRateStrong = 0;
            FindAnyObjectByType<AudioManager>().Play("AlienLaser2");

        }



        float myTimer = Time.deltaTime;

        innerAttackRate += myTimer;
        innerAttackRateStrong += myTimer;



    }
}


