using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _MovementSpeed;

    [SerializeField] private Rigidbody Rigidbody;

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


    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);

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