using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    bool shouldPlayFallSound = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {

            SoundManager.Instance.PlayBumpSound();
        }

    }


    void Update()
    {
        if (transform.position.y <= 0 && shouldPlayFallSound)
        {
            SoundManager.Instance.PlayFallSound();
            shouldPlayFallSound = false;
        }

    }
}
