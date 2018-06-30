using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularHealthBarUIController : MonoBehaviour {

	private Slider _slider;
	private Image _fillImage;
	private UnitHealth health;
	private float prevHealth;

	[SerializeField] private Color fullColor = Color.green;
	[SerializeField] private Color emptyColor = Color.red;
	void Start () {
		_slider = GetComponent<Slider>();
		_fillImage = GetComponentsInChildren<Image>()[1];
		health = GetComponentInParent<UnitHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (prevHealth != health.HealthAsPercentage) {
			_slider.value = health.HealthAsPercentage * 100;
			prevHealth = health.HealthAsPercentage;
			_fillImage.color = Color.Lerp(emptyColor, fullColor, health.HealthAsPercentage);
		}
	}
}
