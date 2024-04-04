using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _Player;
    [SerializeField] private Vector3 _Offset;

    void Update()
    {
        transform.position = _Player.position + _Offset;

    }
}
