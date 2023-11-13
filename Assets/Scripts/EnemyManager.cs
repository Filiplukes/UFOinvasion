using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{

    public GameObject [] enemyShip;
    public GameObject [] bosShip;
    public float [] spawnTime;
    public Transform enemyParent;  
    public int [] addDMG;
    private float [] innerSpawnTime = {0,0,0,0,0,7,7,4,6};
    private EnemyPoints enemyPoints;
    private bool boss = false;
    private int chanceToBoos;
    private int chanceToBossDif;
    private int score;

    private bool bossDeafeat = false;

    private float spawnTimeBonus = 1F;
    private float spawnDificleTimeBonus = 0F;
    private GameObject Boss;
    private string difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = PlayerPrefs.GetString("setDific");

        switch (difficulty)
        {
            case "1":
                spawnTimeBonus = 0.3F;
                spawnDificleTimeBonus = 0.2F;
                chanceToBossDif = 10;
                chanceToBoos = chanceToBossDif;
                score = 150;
                break;
            case "2":
                spawnTimeBonus = 0.1F;
                spawnDificleTimeBonus = 0.6F;
                chanceToBossDif = 20;
                chanceToBoos = chanceToBossDif;
                score = 75;
                break;
            default:
                chanceToBossDif = 0;
                chanceToBoos = chanceToBossDif;
                score = 0;
                difficulty = "0";
                break;
        }

        enemyPoints = FindAnyObjectByType<EnemyPoints>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!boss)
        {
            

            if (Score.scoreValue < 1550)
            {
                spawnLogic(0);
            }
      
           spawnLogic(1);
           spawnLogic(2);
           spawnLogic(3);
            if (bossDeafeat)
            {
                spawnLogic(4);
                
            }
            if (Score.scoreValue > 800)
            {
                spawnLogic(5);
            }

            if (Score.scoreValue > 1550)
            {
                spawnLogic(6);
                spawnLogic(7);
            }

            if (Score.scoreValue > 2700)
            {
                spawnLogic(8);
            }


        }

        if (chanceToBoos > 200) { chanceToBoos = 199; }

            if (chanceToBoos > 150) {
            int spanw = Random.Range(chanceToBoos, 150);
            if (spanw==200) {
                chanceToBoos = chanceToBossDif;
                boss = true;
                Score.scoreValue += score;
                StartCoroutine(waitforSpamBoss());
                spawnTimeBonusLogic();
                }

            }


        }
   
    private void spawnTimeBonusLogic() {

        if (spawnTimeBonus > (0 - spawnDificleTimeBonus))
        {
            spawnTimeBonus = spawnTimeBonus - 0.1F;
        }
    }
    private void SpawnEnemy(int idShip) { 
    
     GameObject enemy =  Instantiate(enemyShip[idShip],enemyPoints.GetRandomSpwanPoint());
        if (enemy.GetComponent<Attack>() != null) {
            enemy.GetComponent<Attack>().buffDmg(addDMG[idShip]);
        }
     
     enemy.transform.SetParent(enemyParent);
    

    }

    private void SpawnBoss(int idBoss)
    {
         

        Boss = Instantiate(bosShip[idBoss], enemyPoints.GetRandomSpwanPoint());
        Boss.transform.SetParent(enemyParent);
        FindAnyObjectByType<AudioManager>().Play("BosSound");
        FindAnyObjectByType<AudioManager>().Stop("BackGround");

    }

    private void spawnLogic(int idObject) {
 
        if (innerSpawnTime[idObject] >= (spawnTime[idObject] + spawnTimeBonus))
        {
            innerSpawnTime[idObject] = 0;
            SpawnEnemy(idObject);    
            chanceToBoos += 1;
        }
        innerSpawnTime[idObject] += Time.deltaTime;


    }

    public void setFalseActiveBoss() {

        boss = false;
        FindAnyObjectByType<AudioManager>().Stop("BosSound");
        FindAnyObjectByType<AudioManager>().Play("BackGround");

    }


    IEnumerator waitforSpamBoss()
    {
        bossDeafeat = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5 - int.Parse(difficulty));
        int typeBoss = Random.Range(0, 8);
        SpawnBoss(typeBoss);
    }


}

