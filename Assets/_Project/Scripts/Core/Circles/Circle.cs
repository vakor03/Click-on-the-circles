using System;
using System.Collections.Generic;
using _Project.Scripts.Configs;
using DG.Tweening;
using MEC;
using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    public class Circle : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private Color _color;
        private float _size;
        private float _lifeTime;
        private float _startScale;
        private float _growDuration;
        private float _popDuration;
        private float _popScale;
        
        private Sequence _popSequence;
        private Sequence _growSequence;

        public event Action<Circle> OnCircleClicked;
        public event Action<Circle> OnCircleDestroyed;

        public void Initialize(Color color, float size, float lifetime, CircleAnimationConfigSO circleAnimationConfigSO)
        {
            _size = size;
            _lifeTime = lifetime;
            _startScale = circleAnimationConfigSO.startScale;
            _growDuration = circleAnimationConfigSO.growDuration;
            _popDuration = circleAnimationConfigSO.popDuration;
            _popScale = circleAnimationConfigSO.popScale;
            
            spriteRenderer.color = color;
        }

        private void Start()
        {
            RunGrowAnimation();
        }

        private void OnDestroy()
        {
            _growSequence?.Kill();
            _popSequence?.Kill();
        }

        public void RunCircleClickedBehaviour()
        {
            OnCircleClicked?.Invoke(this);
            RunPopUpAnimation();
        }

        public void DestroySelf()
        {
            OnCircleDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
        private void RunPopUpAnimation()
        {
            var currentScale = transform.localScale;

            _popSequence = DOTween.Sequence();

            _popSequence.Append(transform.DOScale(_popScale * currentScale, _popDuration / 2));
            _popSequence.Append(transform.DOScale(currentScale, _popDuration / 2));
            _popSequence.OnComplete(DestroySelf);

            _popSequence.Play();
        }

        private void RunGrowAnimation()
        {
            transform.localScale = Vector3.one * _startScale * _size;

            _growSequence = DOTween.Sequence();

            _growSequence.Append(transform.DOScale(Vector3.one * _size, _growDuration));
            _growSequence.OnComplete(StartCountdown);
            _growSequence.Play();
        }

        private void StartCountdown()
        {
            Timing.RunCoroutine(CountdownCoroutine().CancelWith(gameObject));
        }

        private IEnumerator<float> CountdownCoroutine()
        {
            yield return Timing.WaitForSeconds(_lifeTime);
            DestroySelf();
        }
    }
}