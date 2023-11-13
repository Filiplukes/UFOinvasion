using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxer : MonoBehaviour
{

    public GameObject backGroundPref0;
    public GameObject backGroundPref1;
    public GameObject backGroundPref2;
    public float speed;
    public float distance;


    //private long survivedDays = 0;
    private List<GameObject> backGroundsList = new List<GameObject>();
    private int dayCycle = 0;
    private int count = 0;
    private int bgState = 1;

    void Start()
    {
        spawnBackGround(new Vector3(-2F, 0, 0), backGroundPref0);
        spawnBackGround(new Vector3((1 * distance) - 1.5F, 0, 0), backGroundPref1);
        spawnBackGround(new Vector3((2 * distance) - 1.5F, 0, 0), backGroundPref2);


    }


    private void FixedUpdate()
    {
        Shift();
    }

    /* private void CheckRotation(GameObject jumpBg) { 


     }*/

    private void spawnBackGround(Vector3 position, GameObject backGroundUse) {

        GameObject backGoundAdd = Instantiate(backGroundUse, position, Quaternion.identity);
        backGroundsList.Add(backGoundAdd);


    }

    // Update is called once per frame
    void Shift()
    {
            
        foreach (GameObject bg in backGroundsList) {

            Vector2 position = bg.transform.position;
            if (position.x < -20.7F)
            {
                position.x = 30.8F;

                count++;
                if (count == 13) {
                    count = 0;
                    dayCycle++;
                    if (dayCycle > 3) {
                        dayCycle = 0;
                        surviveDays();
                        bgState = bgState + 1;
                        if (bgState > 7) { bgState = 1; }
                    }
                }

                setBackgroundImage(count, bg);


            }
            else {
                position.x -= speed * Time.deltaTime;

            }
            bg.transform.position = position;
        }
    }




    private void setBackgroundImage(int count, GameObject bg) {

        if (dayCycle == 0)
        {
            toOragne(count, bg, true);

        }
        else if (dayCycle == 1)
        {
            toNight(count, bg);

        }
        else if (dayCycle == 2)
        {
            toOragne(count, bg, false);
        }
        else {
            toDay(count, bg);
        }
        
    }




    private void toOragne(int count, GameObject bg, bool toNight) {



        switch (count)
        {
            case 9:
                if (toNight) { 
                    if(bgState > 4){
                        setBgImage("bacgroundPrechodSnihMO", bg);

                    }
                    else
                    {
                       setBgImage("bacgroundPrechodMO", bg);
                    }
                     
                }
                if (!toNight) {
                    if (bgState > 4)
                    {
                        setBgImage("bacgroundPrechodSnihNO", bg);

                    }
                    else
                    {
                        setBgImage("bacgroundPrechodNO", bg);
                    }
                    
                }
                break;
            case 10:
                if (bgState > 4)
                {
                    setBgImage("pozadiOrngSnih1", bg);

                }
                else
                {
                    setBgImage("pozadiOrng", bg);
                }                
                break;
            case 11:
                if (bgState > 4)
                {
                    setBgImage("pozadiOrngSnih2", bg);

                }
                else
                {
                    setBgImage("pozadiOrng2", bg);
                }             
                break;
            case 12:
                if (bgState > 4)
                {
                    setBgImage("pozadiOrngSnih3", bg);

                }
                else
                {
                    setBgImage("pozadiOrng3", bg);
                }              
                break;
            default:
                break;
        }

    }


    private void toNight(int count, GameObject bg)
    {

        switch (count)
        {
            case 9:
                if (bgState > 4)
                {
                    setBgImage("bacgroundPrechodSnihON", bg);

                }
                else
                {
                    setBgImage("bacgroundPrechodON", bg);
                }
                break;
            case 10:
                if (bgState > 4)
                {
                    setBgImage("pozadiSnihNoc1", bg);

                }
                else
                {
                    setBgImage("pozadiNoc1", bg);
                }               
                break;
            case 11:
                if (bgState > 4)
                {
                    setBgImage("pozadiSnihNoc2", bg);

                }
                else
                {
                    setBgImage("pozadiNoc2", bg);
                }            
                break;
            case 12:
                if (bgState > 4)
                {
                    setBgImage("pozadiSnihNoc3", bg);

                }
                else
                {
                    setBgImage("pozadiNoc3", bg);
                }             
                break;
            default:
                break;
        }

    }





    private void toDay(int count, GameObject bg)
    {
  
        switch (count)
        {
            case 9:
                if (bgState > 4)
                {
                    setBgImage("bacgroundPrechodSnihOM", bg);

                }
                else
                {
                    setBgImage("bacgroundPrechodOM", bg);
                }         
                break;
            case 10:
                if (bgState > 4)
                {
                    setBgImage("BackgroungSnih0", bg);

                }
                else
                {
                    setBgImage("Backgroung0", bg);
                }          
                break;
            case 11:
                if (bgState > 4)
                {
                    setBgImage("BackgroundSnih2", bg);

                }
                else
                {
                    setBgImage("Background2", bg);
                }  
                break;
            case 12:
                if (bgState > 4)
                {
                    setBgImage("BackgroundSnih1", bg);

                }
                else
                {
                    setBgImage("Background1", bg);
                }         
                break;
            default:
                break;
        }

    }


    private void surviveDays(){
        //survivedDays++;

        string survivedDays = PlayerPrefs.GetString("survivedDays");

        

        long survivedDaysUpload;

        if (survivedDays == "")
        {

            survivedDaysUpload = 1L;
        }
        else
        {

            survivedDaysUpload = long.Parse(survivedDays) + 1;

        }
        PlayerPrefs.SetString("survivedDays", survivedDaysUpload.ToString());


    }

    private void setBgImage(string image, GameObject bg) {


        bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(image);


    }


}
