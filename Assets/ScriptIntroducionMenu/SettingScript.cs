using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public Image MusicNot;
    public Image SoundNot;
    public GameObject Direction;
   
    public void turnOffMusic() {

        var active = PlayerPrefs.GetString("MusicActive");
        if (active == "1")
        {
            active = "0";
            MusicNot.enabled = false;
        }
        else
        {
            active = "1";
            MusicNot.enabled = true;
        }

        PlayerPrefs.SetString("MusicActive", active);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().setVolume();
    }
    public void turnOffSound()
    {
        var active = PlayerPrefs.GetString("SoundActive");

        if (active == "1")
        {
            active = "0";
            SoundNot.enabled = false;
        }
        else
        {
            active = "1";
            SoundNot.enabled = true;
        }
        PlayerPrefs.SetString("SoundActive", active);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().setVolume();
        
    
}

    public void changeDirection()
    {
        var inGameToggle = GameObject.Find("direction");
        var active = "0";
        if (inGameToggle.GetComponent<Toggle>().isOn)
        {
            active = "1";
        }
        PlayerPrefs.SetString("Direction",active);
    }
}
