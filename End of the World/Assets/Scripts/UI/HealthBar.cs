using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Gradient gradient;
	public Image fillImage;
	[SerializeField] private Slider slider;

	public void SetMaxHealth(float health)
	{
		fillImage.color = gradient.Evaluate(1f);

		slider.maxValue = health;
		slider.value = health;
	}

    public void SetHealth(float health)
	{
		slider.value = health;
		fillImage.color = gradient.Evaluate(slider.normalizedValue);
	}
}
