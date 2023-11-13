
using UnityEngine;

public class HealBuf1 : BuffScript
{

    protected new void OnEnable()
    {
        speed = Random.Range(0, 150) + speed;

     

      positiv = true;
      gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);


        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.left * speed);
        Destroy(gameObject, 6);
    }

    public int getStatHeal()
    {

            return 100;

    }

}
