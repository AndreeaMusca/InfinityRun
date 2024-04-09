using UnityEngine;

public class GrowAppear : MonoBehaviour
{
	[SerializeField] private float _ScaleTarget = 1;
	[SerializeField] private float _GrowthFactor = 1;
	private Vector3 _targetVector;

	void Start()
	{
		transform.localScale = Vector3.zero;
		_targetVector = Vector3.one * _ScaleTarget;
	}

	void Update()
	{
		Vector3 growth = Vector3.zero;
		if (transform.localScale.x < _targetVector.x)
		{
			growth += new Vector3(growth.x + _GrowthFactor * Time.deltaTime, growth.y, growth.z);
		}
		if (transform.localScale.y < _targetVector.y)
		{
			growth += new Vector3(growth.x, growth.y + _GrowthFactor * Time.deltaTime, growth.z);
		}
		if (transform.localScale.z < _targetVector.z)
		{
			growth += new Vector3(growth.x, growth.y, growth.z + _GrowthFactor * Time.deltaTime);
		}

		transform.localScale += growth;
	}
}
