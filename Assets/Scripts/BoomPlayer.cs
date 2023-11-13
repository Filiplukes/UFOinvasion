using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPlayer : MonoBehaviour{


   public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("EnemyShip"))
        {
            player.GetComponent<PlaneShip>().TakeDamage(500);
        }


    }
}
