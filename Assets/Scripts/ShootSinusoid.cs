using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSinusoid : MonoBehaviour
{



    public float moveSpeed;
    public float frequency;
    public float magnitude;
    public int damage;
    
    private float sinCenterY;
    private Vector2 pos;


    void OnEnable()
    {

        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.right * -1 * moveSpeed);
        Destroy(gameObject, 5);


    }

    // Start is called before the first frame update
    void Start()
    {


        sinCenterY = transform.position.y;

      
    }

  
    // Update is called once per frame
    void FixedUpdate()
    {


        Move();
        
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

        if (collision.CompareTag("EnemyShip"))
        {

            collision.gameObject.GetComponent<EnemyShip>().TakeDamage(damage);
            Destroy(gameObject);

        }




    }


    private void Move() { 
    
        pos= transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * magnitude;
        pos.y = sinCenterY + sin;
        transform.position = pos;
        
    
    }



}
