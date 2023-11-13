using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{


    private float timeBuff = 0;
    private bool flashOn = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeSelf)
        {

            if (this.timeBuff > 12)
            {
                this.timeBuff = 0;
                gameObject.SetActive(false);
                flashOn = false;
                

            }
            else
            {

                if (this.timeBuff > 10 & !flashOn)
                {
                     gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("flash");
                    flashOn = true;
                }
                else if (this.timeBuff > 10 & flashOn)
                {

                   gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("green");
                    flashOn = false;

                }


                this.timeBuff += Time.deltaTime;
            }



        }

       
    }


    public void SetActiveTime() {

        gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("green");
        this.timeBuff = 0;


    }




}
