using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] SceneType _type;

    enum SceneType
    {
        InGame,
        Result
    }

    private void Start()
    {
        if (_type == SceneType.Result)
        {
            _scoreText.text = $"SCORE\n{ScoreManager.Instance.score.ToString():00000}";
        }

    }
    private void Update()
    {
        if (_type == SceneType.InGame)
        {
            _scoreText.text = $"SCORE\n{ScoreManager.Instance.score.ToString():00000}";
        }
    }
}
