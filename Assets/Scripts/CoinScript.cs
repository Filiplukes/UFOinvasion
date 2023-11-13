
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public int speed;


    protected void OnEnable()
    {
        speed = Random.Range(0, 150) + 200;
        FindFirstObjectByType<Rigidbody2D>().AddForce(Vector2.left * speed);
        Destroy(gameObject, 6);
    }


    public void DestroyBuff()
    {


        Destroy(gameObject);


    }



}
