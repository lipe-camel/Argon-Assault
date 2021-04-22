using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Color32 c1, c2, c3, c4;
    [SerializeField] float frameRate = 12f;

    //CACHED COMPONENT REFERENCES
    Slider slider;
    RawImage fillColor;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        fillColor = GetComponentInChildren<RawImage>();
    }
    private void OnEnable()
    {
        StartCoroutine(FlashColors());
    }

    private IEnumerator FlashColors()
    {
        while (true)
        {
            fillColor.color = c1;
            yield return new WaitForSeconds(1 / frameRate);
            fillColor.color = c2;
            yield return new WaitForSeconds(1 / frameRate);
            fillColor.color = c3;
            yield return new WaitForSeconds(1 / frameRate);
            fillColor.color = c4;
            yield return new WaitForSeconds(1 / frameRate);
        }
    }

    public void UpdateDisplay(float health)
    {
        slider.value = health;
    }
}