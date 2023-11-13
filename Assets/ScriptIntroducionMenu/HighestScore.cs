
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour
{
    public Text txt;
    private long score;
    void Start()
    {
        string stringScore = PlayerPrefs.GetString("HighScore");



        if (stringScore == "")
        {
           
            score = 0L;
        }
        else {
         
            score = long.Parse(stringScore);

        }

        txt.GetComponent<UnityEngine.UI.Text>().text = "Highest score " + score;

    }


}












