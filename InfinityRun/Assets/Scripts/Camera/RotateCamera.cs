using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	[SerializeField] float _Speed = 2.0f;

	void Update()
	{
		transform.Rotate(Vector3.up * _Speed * Time.deltaTime);
	}
}
