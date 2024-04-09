using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _TextScore;
	public int score = 0;
	private float _score = 0;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		_score += 2*Time.deltaTime;
		score = (int)_score;
		_TextScore.text = score.ToString();
	}
}