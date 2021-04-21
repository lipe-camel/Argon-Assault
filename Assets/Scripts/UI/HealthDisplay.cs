using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //Slider slider;

    //private void Start()
    //{
    //    slider = GetComponent<Slider>();
    //}

    public void UpdateDisplay(float health)
    {
        GetComponent<Slider>().value = health;
    }
}