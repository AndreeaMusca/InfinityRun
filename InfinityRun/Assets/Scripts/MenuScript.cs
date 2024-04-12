using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _HighestScore;
    [SerializeField] private TextMeshProUGUI _LatestScore;

    public void LoadMainLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        _HighestScore.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        _LatestScore.text = "Latest Score: " + PlayerPrefs.GetInt("LatestScore", 0).ToString();
    }
}
