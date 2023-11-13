using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int damage;
    public int direction;
    public float force;
    public float lifeTime;
 


    void OnEnable()
    {


        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.right * direction * force);
        Destroy(gameObject,lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Shield"))
        {

            Destroy(gameObject);
        } else if (collision.CompareTag("Player")) {

            collision.gameObject.GetComponent<PlaneShip>().TakeDamage(damage);
            Destroy(gameObject);
        }
     
        if (collision.CompareTag("EnemyShip"))
        {

            collision.gameObject.GetComponent<EnemyShip>().TakeDamage(damage);
            Destroy(gameObject);

        }
       

    }

    public void addDmg(int addDmg) { 
    
    
        damage+=addDmg;
        if (damage < 0) {
            damage = 0;
        }
    
    }
}
