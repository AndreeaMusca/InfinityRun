using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;

    [SerializeField] private Rigidbody Rigidbody;

    private int jumpCount = 0;

    private int maxJumpCount = 2;

    public float MovementSpeed
    {
        get { return _MovementSpeed; }
        set { _MovementSpeed = value; }
    }

    void Start()
    {

    }

    public void GoForward()
    {
        transform.Translate(Vector3.forward * _MovementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {

            Rigidbody.AddForce(Vector3.up * 8, ForceMode.Impulse);
            SoundManager.Instance.PlayJumpSound();
            jumpCount++;
        }
    }

    public void Slide()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * MovementSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
    void Update()
    {
        GoForward();
        Jump();
        Slide();

    }
}