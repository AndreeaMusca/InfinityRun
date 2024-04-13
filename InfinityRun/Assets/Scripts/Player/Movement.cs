using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private float _MovementSpeed;
	private Rigidbody _rigidbody;

	private int _jumpCount = 0;
	private int _maxJumpCount = 2;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		InvokeRepeating(nameof(IncreaseSpeed), 0f, 5f);
	}

	private void IncreaseSpeed()
	{
		_MovementSpeed += 5;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			_jumpCount = 0;
		}
	}

	public void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < _maxJumpCount)
		{
			_rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
			SoundManager.Instance.PlayJumpSound();
			_jumpCount++;
		}
	}

	void Update()
	{
		Vector3 translation = Vector3.forward * _MovementSpeed;
		translation.x = Input.GetAxis("Horizontal") * 35;
		transform.Translate(translation * Time.deltaTime);

		Jump();
	}
}