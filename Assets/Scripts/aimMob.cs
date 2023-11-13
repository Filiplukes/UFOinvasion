
using UnityEngine;


public class aimMob : EnemyShip
{

    public int score;
    public GameObject speedBuffs;
    public GameObject dmgBuff;
    public GameObject healBuff;
    public GameObject shieldBuff;
    public GameObject coin;


    private void FixedUpdate()
    {
        Move();
    }


    protected override void DestoyShip()
    {
        try
        {

            Score.scoreValue += score;

            int bufSpam = Random.Range(0, 45);

            if (bufSpam == 1)
            {
                GameObject buff = Instantiate(speedBuffs);
                buff.transform.position = transform.position;
            }
            if (bufSpam == 16)
            {
                GameObject buff = Instantiate(dmgBuff);
                buff.transform.position = transform.position;
            }
            if (bufSpam == 31 || bufSpam == 32)
            {
                GameObject buff = Instantiate(healBuff);
                buff.transform.position = transform.position;
            }

            if (bufSpam == 40)
            {
                GameObject buff = Instantiate(shieldBuff);
                buff.transform.position = transform.position;
            }

            if (bufSpam == 13)
            {
                GameObject buff = Instantiate(coin);
                buff.transform.position = transform.position;
            }
            FindFirstObjectByType<AudioManager>().Play("AlienExplosion");

        }
        catch
        {

        }
        base.DestoyShip();

    }

    private void Move() {

        var target = GameObject.FindGameObjectsWithTag("Player");

        if (target.Length > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target[1].transform.position, 2 * Time.deltaTime);
        }

    }
}

