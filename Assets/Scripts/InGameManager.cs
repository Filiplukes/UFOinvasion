using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{

    private long KillAliens = 0;
    private string aktual;

    private void Start()
    {
        startGame();
    }
    public void EndGame() {
        SceneManager.LoadScene("StartPage");
    }


    public void plusKills() {

        KillAliens++;

    }

    public long getKillsAliens() {

        return KillAliens;
    }

    public void startGame(){

        aktual = PlayerPrefs.GetString("AktualSkin");
        if (aktual == "")
        {
            aktual = "0";
        }

        var m_NewPosition = new Vector2(-6.5f, 0.0f);
        var loadedObject = Resources.Load("plane/Plane" + aktual);
        Instantiate(loadedObject, m_NewPosition, Quaternion.identity);
    }

}
