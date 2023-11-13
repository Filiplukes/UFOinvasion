using System;
using UnityEngine;

public class aimShoot : Shoot
{
    // Start is called before the first frame update
    void OnEnable()
    {

       // FindObjectOfType<Rigidbody2D>().AddForce(Vector2.right * direction * force);

        var target = GameObject.FindGameObjectsWithTag("Player");

        if (target.Length > 1) {
            FindFirstObjectByType<Rigidbody2D>().AddForce((target[1].transform.position - gameObject.transform.position).normalized * force);
        }
        else {

            FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.left * 1 * 100);
          
        }

        Destroy(gameObject, lifeTime);
    }

}
