using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var active = PlayerPrefs.GetString("Direction");
        if (active == "1")
        {
            transform.rotation *= Quaternion.Euler(0, 180f, 0);
            transform.position = new Vector3(0f, 0f, 10f);
        }
       
    }
}
