
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public static long scoreValue;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        scoreText = GetComponent<Text>();

        
    }

    public long getScore() { 
    
        return scoreValue;
    
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text ="Score: " + scoreValue.ToString();
        
    }
}
