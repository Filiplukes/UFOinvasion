using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{


    private static long scoreValue;
    Text scoreText;

    public void setScore(long scoreText) {
        this.scoreText.text = scoreText.ToString();


    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Your score is: " + scoreValue.ToString();

    }


}

