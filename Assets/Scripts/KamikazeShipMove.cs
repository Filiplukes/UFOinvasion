using UnityEngine;

public class KamikazeShipMove : EnemyShip
{
    public float speed;
    public int score;


    public GameObject speedBuffs;
    public GameObject dmgBuff;
    public GameObject healBuff;
    public GameObject shieldBuff;
    public int destroyTime;


    protected override void Start()
     {

        base.Start();
        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.right * -1 * speed);

        Destroy(gameObject, destroyTime);
    }



    protected override void DestoyShip()
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
        if (bufSpam == 31)
        {
            GameObject buff = Instantiate(healBuff);
            buff.transform.position = transform.position;
        }

        if (bufSpam == 40)
        {
            GameObject buff = Instantiate(shieldBuff);
            buff.transform.position = transform.position;
        }
        FindFirstObjectByType<AudioManager>().Play("AlienExplosion");
        base.DestoyShip();
    }



}
