using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthNumberDisplay;

    public void SetMaxHealth(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
        fill.color = gradient.Evaluate(1f);
        healthNumberDisplay.text = slider.value.ToString() + " / " + slider.maxValue.ToString();
    }

    public void SetHealth(int _health)
    {
        slider.value = _health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        healthNumberDisplay.text = slider.value.ToString() + " / " + slider.maxValue.ToString();

    }
}
