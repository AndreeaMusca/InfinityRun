using UnityEngine;

public class BrushOutOfSight : MonoBehaviour
{
	private GameObject _camera;

	void Start()
	{
		_camera = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update()
	{
		if (transform.position.z < _camera.transform.position.z)
		{
			Destroy(gameObject);
			return;
		}
	}
}
