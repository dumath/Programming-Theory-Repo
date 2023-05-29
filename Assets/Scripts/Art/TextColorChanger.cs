using UnityEngine;
using TMPro;

public class TextColorChanger : MonoBehaviour
{
    [SerializeField] private Color minColor = Color.black;
    [SerializeField] private Color maxColor = Color.white;

    [Range(0, 100)] [SerializeField] private int flickerFrequency;

    [SerializeField] private TMP_Text buttonText;

    private float modifier = 1.0f;

    private void Update()
    {
        buttonText.color += Color.Lerp(minColor, maxColor, 0.001f * flickerFrequency) * modifier;
        if (AdditionalMath.RGBAverage(buttonText.color) > AdditionalMath.RGBAverage(Color.white)) 
            modifier *= -modifier;
        if (AdditionalMath.RGBAverage(buttonText.color) < AdditionalMath.RGBAverage(Color.black)) 
            modifier *= modifier;
    }
}
