using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TextScore;
    private int highScore = 0;
    private int latestScore = 0;
    private string highScoreKey = "HighScore";
    private string latestScoreKey = "LatestScore";


    public int score = 0;
    private float _score = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        latestScore = PlayerPrefs.GetInt(latestScoreKey, 0);
    }

    public void UpdateHighestScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(highScoreKey, highScore);
        }
    }

    public void UpdateLatestScore()
    {
        latestScore = score;
        PlayerPrefs.SetInt(latestScoreKey, latestScore);
    }
    void Update()
    {
        _score += 2 * Time.deltaTime;
        score = (int)_score;
        _TextScore.text = score.ToString();
    }

    public void AddBonus()
    {
        _score += 50;
        System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
        Debug.Log(t);

    }
}