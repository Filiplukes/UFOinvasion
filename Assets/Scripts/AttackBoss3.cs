using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss3 : AttackBoss2
{
 

    // Update is called once per frame
    void Update()
    {
        attackRateStrong = 2.3f;

        if (innerAttackRate > attacRate)
        {
            foreach (Transform t in firePoints)
            {

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
            if (innerAttackRateStrong > 3) {
                innerAttackRateStrong = 0;
            }

            FindAnyObjectByType<AudioManager>().Play("AlienLaser2");

        }



        float myTimer = Time.deltaTime;

        innerAttackRate += myTimer;
        innerAttackRateStrong += myTimer;


    }
}
