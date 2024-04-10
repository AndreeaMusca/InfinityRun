using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TextScore;

    public int score = 0;
    private float _score = 0;

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