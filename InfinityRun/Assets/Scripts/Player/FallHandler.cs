using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallHandler : MonoBehaviour
{
	bool shouldPlayFallSound = true;
	void Update()
	{
		if (transform.position.y <= 0 && shouldPlayFallSound)
		{
			SoundManager.Instance.PlayFallSound();
			shouldPlayFallSound = false;
			StartCoroutine(NewMethod());
		}
	}

	private IEnumerator NewMethod()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(2);
	}
}
