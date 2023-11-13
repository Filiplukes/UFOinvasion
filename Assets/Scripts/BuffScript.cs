
using UnityEngine;

public class BuffScript : MonoBehaviour
{

    protected bool positiv;

    public int speed;


    protected void OnEnable()
    {
        speed = Random.Range(0, 150) + speed;

        if (Random.Range(0, 2) == 1)
        {

            positiv = true;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        }
        else
        {

            positiv = false;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }




        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.left * speed);
        Destroy(gameObject, 6);
    }


    public float getStat()
    {

        if (positiv)
        {

            return -0.1f;
        }

        return 0.1f;

    }


    public void DestroyBuff()
    {


        Destroy(gameObject);


    }



}
