using UnityEngine;
using UnityEngine.UI;

public class SetDific : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] setDific = {"Easy", "Normal", "Hard"};
    private int aktualDif;
    public Text placeholder;
    void Start()
    {
       string pomDif = PlayerPrefs.GetString("setDific");
        if (pomDif == "") { pomDif = "0"; };
       aktualDif = int.Parse(pomDif);
       placeholder.GetComponent<Text>().text = setDific[aktualDif];

    }


   public void nextDif()
    {
        if(aktualDif < 2) { 
            aktualDif++;
        }
        else
        {
            aktualDif = 0;
        }
        placeholder.GetComponent<Text>().text = setDific[aktualDif];
        PlayerPrefs.SetString("setDific",aktualDif.ToString());

    }
    public void backDif()
    {
        if (aktualDif > 0)
        {
            aktualDif--;
        }
        else
        {
            aktualDif = 2;
        }
        placeholder.GetComponent<Text>().text = setDific[aktualDif];
        PlayerPrefs.SetString("setDific", aktualDif.ToString());

    }

    public int getDif() {

        return aktualDif; 
    
    }
}
