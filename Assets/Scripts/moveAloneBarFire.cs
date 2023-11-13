using UnityEngine;

public class moveAloneBarFire : MonoBehaviour
{
    private GameObject pointStay;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pointStay = GameObject.Find("TestPoint");
    }

    // Update is called once per frame

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, pointStay.transform.position, speed * Time.fixedDeltaTime);

        }

    
}
