using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : BuffScript
{
    new void OnEnable()
    {
        speed = Random.Range(0, 150) + speed;

        positiv = true;
        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.left * speed);
        Destroy(gameObject, 6);
    }

}



