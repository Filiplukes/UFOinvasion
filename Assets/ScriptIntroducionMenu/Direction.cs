using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var active = PlayerPrefs.GetString("Direction");
        if (active == "1")
        {
            gameObject.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            gameObject.GetComponent<Toggle>().isOn = false;

        }

    }

}
