
using UnityEngine;
using UnityEngine.UI;

public class SetTopScore : MonoBehaviour
{
    public Text topscoretext;
    // Start is called before the first frame update
    void Start()
    {
        var score =  PlayerPrefs.GetString("HighScore");
        if (score == null) { score = "0"; }
        topscoretext.text = "Your top score is: " + score; 
    }

}
