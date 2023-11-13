using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achiev : MonoBehaviour
{


    public Text txt;
    public string NameAchiev;
    public long [] count;

    void Start()
    {


        string scoreAchiev = PlayerPrefs.GetString(NameAchiev);

        if (scoreAchiev == "") scoreAchiev = "0";


        

        if (long.Parse(scoreAchiev) >= count[2])
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Gold");
        }
        else if (long.Parse(scoreAchiev) >= count[1])
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Silver");
        }
        else if (long.Parse(scoreAchiev) >= count[0])
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bronze");
        }
        else {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("WhiteAch");

        }

        txt.GetComponent<UnityEngine.UI.Text>().text = txt.GetComponent<UnityEngine.UI.Text>().text +": "+ scoreAchiev;

    }

   
}
