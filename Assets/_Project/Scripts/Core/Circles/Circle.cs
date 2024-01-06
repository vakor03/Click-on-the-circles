using System;
using System.Collections.Generic;
using DG.Tweening;
using MEC;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Core.Circles
{
    // TODO: Add circle size and color
    // TODO: Animation for circle
    // TODO: Animation for circle click
    // TODO: Handle circle click(add score)
    // TODO: Circle spawn
    // TODO: Countdown timer
    // TODO: Input system
    public class Circle : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        [SerializeField] private float _size;
        private Color _color;
        [SerializeField]
        private float _lifeTime = 5f;

        [SerializeField] private float startScale = 0.1f;


        [SerializeField] private float _growDuration;

        [SerializeField] private float _popDuration;

        [SerializeField] private float popScale = 1.5f;

        public event Action<Circle> OnCircleClicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (circleCollider2D.OverlapPoint(mousePosition))
                {
                    Debug.Log("Circle clicked");
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

            popSequence.Append(transform.DOScale(popScale * currentScale, _popDuration / 2));
            popSequence.Append(transform.DOScale(currentScale, _popDuration / 2));
            popSequence.OnComplete(DestroySelf);

            popSequence.Play();
        }

        private void RunGrowAnimation()
        {
            transform.localScale = Vector3.one * startScale;

            Sequence growSequence = DOTween.Sequence();

            growSequence.Append(transform.DOScale(Vector3.one * _size, _growDuration));
            growSequence.OnComplete(StartCountdown);
            growSequence.Play();
        }

        private void StartCountdown()
        {
            Timing.RunCoroutine(CountdownCoroutine());
        }

        private IEnumerator<float> CountdownCoroutine()
        {
            yield return Timing.WaitForSeconds(_lifeTime);
            DestroySelf();
        }
        
        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}