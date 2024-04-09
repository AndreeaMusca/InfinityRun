using UnityEngine;

public class InfinitePlane : MonoBehaviour
{
	[SerializeField] private Transform _PlayerTransform;
	void Update()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, _PlayerTransform.position.z);
	}
}
