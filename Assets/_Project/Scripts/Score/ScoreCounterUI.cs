using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Score
{
    public class ScoreCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private IScoreCounterService _scoreCounter;
        
        [Inject]
        private void Construct(IScoreCounterService scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }
        
        private void Start()
        {
            UpdateScore();
        }
        
        private void OnEnable()
        {
            _scoreCounter.OnScoreChanged += HandleScoreChanged;
        }
        
        private void HandleScoreChanged()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            scoreText.text = $"Score: {_scoreCounter.CurrentScore}";
        }

        private void OnDisable()
        {
            _scoreCounter.OnScoreChanged -= HandleScoreChanged;
        }
    }
}