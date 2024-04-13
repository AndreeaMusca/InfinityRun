using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private int _lives = 3;
    private Collider _previousCollider = null;
    private Collider _previousBonus = null;

    [SerializeField] private GameObject _FirstHeart;
    [SerializeField] private GameObject _SecondHeart;
    [SerializeField] private GameObject _ThirdHeart;

    [SerializeField] private ParticleSystem _Impact;


    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Asteroid"))
        {
            if (_previousCollider == collider)
            {
                return;
            }
            _Impact.Play();
			_previousCollider = collider;
            SoundManager.Instance.PlayBumpSound();
            _lives--;
            DisableHeart();
            if (_lives == 0)
            {
                PlayerScore playerScore = FindObjectOfType<PlayerScore>();
                playerScore.UpdateHighestScore();
                playerScore.UpdateLatestScore();

                StartCoroutine(NewMethod());
                SceneManager.LoadScene(2);
            }
        }
        if (collider.gameObject.CompareTag("Bonus"))
        {
            if (_previousBonus == collider)
            {
                return;
            }
            _previousBonus = collider;
            PlayerScore playerScore = FindObjectOfType<PlayerScore>();
            Destroy(_previousBonus.gameObject);
            playerScore.AddBonus();
            SoundManager.Instance.PlayBonusSound();
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
