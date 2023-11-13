using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBoss : EnemyShipMove
{
    public GameObject healBuff1;
    public int bossID;
    private GameObject enemyManager;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        moveShip();
    }




    protected override void DestoyShip()
    {
        base.DestoyShip();

        setBossSpeciesAchievmet();
        
        GameObject buff = Instantiate(healBuff1);  
        buff.transform.position = transform.position;
   


        enemyManager = GameObject.Find("EnemyManager");

        enemyManager.GetComponent<EnemyManager>().setFalseActiveBoss();


    }

    private void setBossSpeciesAchievmet()
    {

        string bossKilledSpecies = PlayerPrefs.GetString("BossKilledSpecies");



        if (bossKilledSpecies == "")
        {

            bossKilledSpecies = "0000";
        }

        bossKilledSpecies = bossKilledSpecies.Remove(bossID, 1).Insert(bossID, "1");
        PlayerPrefs.SetString("BossKilledSpecies", bossKilledSpecies);


        string bossKilled = PlayerPrefs.GetString("BossKilled");
        if (bossKilled == "") { bossKilled = "0"; }

        int bossKilledInt = int.Parse(bossKilled) + 1;


        PlayerPrefs.SetString("BossKilled", bossKilledInt.ToString());



    }



}
