using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{

    public Gradient gradient;
    public Slider slider;
    public Image filler;

    public void setMaxHealth(int health) {

        slider.maxValue = health;
        slider.value = health;
        filler.color = gradient.Evaluate(1f);    
    
    }
    public void setHealth(int health)
    {

        slider.value = health;

        filler.color = gradient.Evaluate(slider.normalizedValue);

    }

}
