using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss4 : Attack
{
    public GameObject kamikPref;
    public GameObject strongkPref;

    public Transform firePoint1;
    public Transform firePoint2;

    private float innerKamikazeRate = 0;
    private float innerStrongRate = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (innerAttackRate > (attacRate))
        {

            innerAttackRate = 0;
            instantShoot(shootPref, attackName);

        }
        if (innerKamikazeRate > (attacRate+1))
        {
            instantShoot(kamikPref, attackName);
            innerKamikazeRate = 0;

        }


        if (innerStrongRate > (attacRate + 0.5))
        {
            instantShoot(strongkPref, attackName);          
         
            innerStrongRate = 0;

        }

        innerAttackRate += Time.deltaTime;
        innerKamikazeRate += Time.deltaTime;
        innerStrongRate += Time.deltaTime;




    }



    private void instantShoot(GameObject instantShoot, string audioShoot) {

        Instantiate(instantShoot, firePoint1.position, Quaternion.identity);

        FindAnyObjectByType<AudioManager>().Play(audioShoot);

    }

   

}
