using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private int _lives = 3;
	private Collider _previousCollider = null;

	[SerializeField] private GameObject _FirstHeart;
	[SerializeField] private GameObject _SecondHeart;
	[SerializeField] private GameObject _ThirdHeart;

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
			DisableHeart();
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

	private void DisableHeart()
	{
		switch (_lives)
		{
			case 0:
				_FirstHeart.SetActive(false);
				break;
			case 1:
				_SecondHeart.SetActive(false);
				break;
			case 2:
				_ThirdHeart.SetActive(false);
				break;
		}	
	}
}
