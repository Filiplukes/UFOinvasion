using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private bool pause = false;
    private Image[] childrenImages;

    private void Start()
    {
        childrenImages = GetComponentsInChildren<Image>();
        childrenImages[2].gameObject.SetActive(false);

    }

    public void PauseGame()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1;
            childrenImages[1].gameObject.SetActive(true);
            childrenImages[2].gameObject.SetActive(false);
        }
        else
        {
            pause = true;
            Time.timeScale = 0;
            childrenImages[1].gameObject.SetActive(false);
            childrenImages[2].gameObject.SetActive(true);
        }

    }


}
