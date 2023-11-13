
using UnityEngine;

public class Laser : Shoot
{

    public int topDirection;



    void OnEnable()
    {


        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.right * direction * force);
        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.up * topDirection * force);



        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlaneShip>().TakeDamage(damage);
            Destroy(gameObject);
        }



    }


    public void addSpeed(int force){
    
    
            this.force = this.force+force;
    
    }



}