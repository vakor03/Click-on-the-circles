using _Project.Scripts.Core.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core
{
    public class DeathScreenUI : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private IScoreCounter _scoreCounter;
        private GameOverStateObserver _gameOverStateObserver;

        [Inject]
        private void Construct(IScoreCounter scoreCounter,
            GameOverStateObserver gameOverStateObserver)
        {
            _scoreCounter = scoreCounter;
            _gameOverStateObserver = gameOverStateObserver;
        }
        
        private void OnEnable()
        {
            _scoreCounter.OnScoreChanged += HandleScoreChanged;
            _gameOverStateObserver.OnGameOverStateChanged += HandleGameOverChanged;
            
            UpdateIsActive();
            UpdateScoreText();
        }

        private void OnDisable()
        {
            _scoreCounter.OnScoreChanged -= HandleScoreChanged;
            _gameOverStateObserver.OnGameOverStateChanged -= HandleGameOverChanged;
        }

        private void UpdateScoreText()
        {
            scoreText.text = $"Score: {_scoreCounter.CurrentScore}";
        }

        private void UpdateIsActive()
        {
            parent.gameObject.SetActive(_gameOverStateObserver.IsGameOver);
        }

        private void HandleGameOverChanged()
        {
            UpdateIsActive();
        }

        private void HandleScoreChanged()
        {
            UpdateScoreText();
        }
    }
}