using _Project.Scripts.Core.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Windows
{
    public class GameOverWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private Transform parent;
        [SerializeField] private TextMeshProUGUI scoreText;

        private IScoreCounter _scoreCounter;

        [Inject]
        private void Construct(IScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
            
            Hide();
        }

        private void OnEnable()
        {
            _scoreCounter.OnScoreChanged += HandleScoreChanged;

            UpdateScoreText();
        }

        private void OnDisable()
        {
            _scoreCounter.OnScoreChanged -= HandleScoreChanged;
        }

        private void UpdateScoreText()
        {
            scoreText.text = $"Score: {_scoreCounter.CurrentScore}";
        }

        private void HandleScoreChanged()
        {
            UpdateScoreText();
        }

        public void Show()
        {
            parent.gameObject.SetActive(true);
        }

        public void Hide()
        {
            parent.gameObject.SetActive(false);
        }
    }
}