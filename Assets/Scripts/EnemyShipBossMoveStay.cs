using UnityEngine;

public class EnemyShipBossMoveStay : EnemyShipBoss
{
    private GameObject pointStay;  
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        pointStay = GameObject.Find("TestPoint");
      //  transform.position = Vector2.MoveTowards(transform.position, pointStay.transform.position, speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointStay.transform.position, speed * Time.fixedDeltaTime);
        
    }


    protected override void DestoyShip()
    {
        base.DestoyShip();
        Destroy(transform.parent.gameObject);


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


        string bossKilled = PlayerPrefs.GetString("BossKilled2");
        if (bossKilled == "") { bossKilled = "0"; }

        int bossKilledInt = int.Parse(bossKilled) + 1;


        PlayerPrefs.SetString("BossKilled2", bossKilledInt.ToString());



    }

    protected override void moveShip() 
    { 
        

    }



}
