
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject shootPref;
    public Transform firePoint;
    public float attacRate;
    public string attackName;

    private float timeBuffSpeed = 0;
    private float speedBuff = 0; 
    private float timeBuffDmg = 0; 
    protected float innerAttackRate = 0;
    private int dmgBuff = 0;


    // Update is called once per frame
    void Update()
    {
        if (innerAttackRate > (attacRate + speedBuff)) { 
        
          GameObject shoot =  Instantiate(shootPref,firePoint.position,Quaternion.identity);

            innerAttackRate = 0;

            if (shoot.GetComponent<Shoot>()) {

                shoot.GetComponent<Shoot>().addDmg(dmgBuff);
            }


            FindFirstObjectByType<AudioManager>().Play(attackName);


        }

        innerAttackRate += Time.deltaTime;

        
       
        if (timeBuffSpeed > 10)
        {
            speedBuff = 0;
            timeBuffSpeed = 0;

        }
        else {
            timeBuffSpeed += Time.deltaTime;

        }

        if (timeBuffDmg > 10)
        {
            dmgBuff = 0;
            timeBuffDmg = 0;

        }
        else {
            timeBuffDmg += Time.deltaTime;

        }

    }


    public void buffSpeed(float add) {
       
        speedBuff += add;
        if (speedBuff < -0.4) speedBuff = -0.4f;
        if (speedBuff > 0.4) speedBuff = 0.4f;
        timeBuffSpeed = 0;


    }

    public void buffDmg(int add)
    {

        dmgBuff += add;
        timeBuffDmg = 0;


    }



}
