using System;
using System.Collections.Generic;
using DG.Tweening;
using MEC;
using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    // TODO: Countdown timer
    // TODO: Input system

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

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (circleCollider2D.OverlapPoint(mousePosition))
                {
                    OnCircleClicked?.Invoke(this);
                    RunPopUpAnimation();
                }
            }
        }

        private void Start()
        {
            RunGrowAnimation();
        }

        private void RunPopUpAnimation()
        {
            var currentScale = transform.localScale;

            Sequence popSequence = DOTween.Sequence();

            popSequence.Append(transform.DOScale(_popScale * currentScale, _popDuration / 2));
            popSequence.Append(transform.DOScale(currentScale, _popDuration / 2));
            popSequence.OnComplete(DestroySelf);

            popSequence.Play();
        }

        private void RunGrowAnimation()
        {
            transform.localScale = Vector3.one * _startScale * _size;

            Sequence growSequence = DOTween.Sequence();

            growSequence.Append(transform.DOScale(Vector3.one * _size, _growDuration));
            growSequence.OnComplete(StartCountdown);
            growSequence.Play();
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

        public void DestroySelf()
        {
            OnCircleDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}