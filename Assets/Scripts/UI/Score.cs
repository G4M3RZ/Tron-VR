using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    [Range(0, 5)] public float _speed;
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _hScoreText;

    private Shield _sh;
    private float _currentScore; 
    private int _highScore;

    private void Awake()
    {
        _sh = GameObject.FindGameObjectWithTag("Player").GetComponent<Shield>();
        _highScore = PlayerPrefs.GetInt("HighScore", 0);

        _scoreText.text = _currentScore.ToString("0");
        _hScoreText.text = "High Score" + "\n" + _highScore;
    }
    private void Update()
    {
        if (!_sh._death)
        {
            _currentScore += Time.deltaTime * _speed;
            _scoreText.text = _currentScore.ToString("0");

            if ((int)_currentScore > _highScore)
            {
                PlayerPrefs.SetInt("HighScore", (int)_currentScore);
                _hScoreText.text = "High Score" + "\n" + (int)_currentScore;
            }
        }
    }
}