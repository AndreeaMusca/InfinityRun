using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private int _lives = 3;
	private Collider _previousCollider = null;

    private void OnTriggerEnter(Collider collider)
    {
		Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Asteroid"))
        {
			if (_previousCollider == collider)
			{
				return;
			}
			_previousCollider = collider;
			SoundManager.Instance.PlayBumpSound();
			_lives--;
			if (_lives == 0)
			{
				StartCoroutine(NewMethod());
				SceneManager.LoadScene(2);
			}
		}
	}


	private IEnumerator NewMethod()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(2);
	}
}
