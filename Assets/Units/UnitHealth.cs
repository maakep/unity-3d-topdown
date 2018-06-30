using UnityEngine;

public class UnitHealth : MonoBehaviour {
  [SerializeField] float maxHealthPoints = 100f;

	[Range(0, 100)] float currentHealthPoints = 100f;

	public float HealthAsPercentage
	{
		get
		{
			return currentHealthPoints / maxHealthPoints;
		}
	}
}