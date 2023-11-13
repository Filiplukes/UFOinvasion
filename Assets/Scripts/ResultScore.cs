
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text txt;
    private long score;
    private long HighScore;
    private InGameManager gameManager;
    public GameObject UpdateScore;

    void Start()
    {
        gameManager = FindAnyObjectByType<InGameManager>();
        long killsAlliens;
        killsAlliens = gameManager.GetComponent<InGameManager>().getKillsAliens();

        highScore();
        destroyShips(gameManager, killsAlliens);
        oneGameKills(gameManager, killsAlliens);

    }



    private void highScore() {


        score = FindAnyObjectByType<Score>().getScore();

        string userNick = PlayerPrefs.GetString("Nick");
        FindAnyObjectByType<HighscoresUpload>().AddNewHighscore(userNick, score);


        string stringScore = PlayerPrefs.GetString("HighScore");

        if (stringScore == "")
        {

            HighScore = 0L;
        }
        else
        {

            HighScore = long.Parse(stringScore);

        }


        if (HighScore < score)
        {

            txt.GetComponent<UnityEngine.UI.Text>().text = "Your score is " + score + ", congratulation its new high score.";
            txt.GetComponent<UnityEngine.UI.Text>().color = Color.red;
            PlayerPrefs.SetString("HighScore", score.ToString());

        }
        else
        {

            txt.GetComponent<UnityEngine.UI.Text>().text = "Your score is " + score;
        }

    }


    private void destroyShips(InGameManager gameManager,long killsAlliens)
    {
        
        string killsAlliensBefore = PlayerPrefs.GetString("KillAliens");

        if (killsAlliensBefore == "") { killsAlliensBefore = "0"; }

        killsAlliens = killsAlliens + long.Parse(killsAlliensBefore);

        PlayerPrefs.SetString("KillAliens", killsAlliens.ToString());
    }



    private void oneGameKills(InGameManager gameManager,long killsAlliens) {


        string killsAlliensBefore = PlayerPrefs.GetString("KillAliensOneGame");
        if (killsAlliensBefore == "") { killsAlliensBefore = "0"; }


        if (long.Parse(killsAlliensBefore) < killsAlliens)
        {

            PlayerPrefs.SetString("KillAliensOneGame", killsAlliens.ToString());
        }


    }



}
