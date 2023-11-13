using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievBossSpecies : MonoBehaviour
{
    public Text txt;
    public string NameAchiev;


    private int species =0;
    void Start()
    {


        string scoreAchiev = PlayerPrefs.GetString(NameAchiev);

        if (scoreAchiev == "") {
            txt.GetComponent<UnityEngine.UI.Text>().text = txt.GetComponent<UnityEngine.UI.Text>().text + ": " + species;
            return;
                };


        for (int i = 0; i < scoreAchiev.Length; i++)
        {
            if (scoreAchiev[i] == '1') { 
                species += 1;
            }
        }


        
                if (species >= 4)
                {
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Gold");
                }
                else if (species >= 2)
                {
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Silver");
                }
                else if (species >= 1)
                {
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bronze");
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("WhiteAch");

                }

        txt.GetComponent<UnityEngine.UI.Text>().text = txt.GetComponent<UnityEngine.UI.Text>().text + ": " + species;

    }

}
