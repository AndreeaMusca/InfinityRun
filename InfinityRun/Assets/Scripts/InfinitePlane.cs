using UnityEngine;

public class InfinitePlane : MonoBehaviour
{
	void Update()
	{
		float snappedZ = Snap((int)Camera.main.transform.position.z);

		transform.position = new Vector3(transform.position.x, transform.position.y, snappedZ);
	}

	int Snap(int value)
	{
		value /= 10;
		value *= 10;
		return value;
	}
}
