using System;
using System.Collections.Generic;

namespace _Project.Scripts.Core.Circles
{
    public class CirclesHolder
    {
        private List<Circle> _circles = new();
        
        public int CirclesCount => _circles.Count;

        public event Action<Circle> OnCircleClicked;

        public void AddCircle(Circle circle)
        {
            _circles.Add(circle);

            circle.OnCircleClicked += HandleCircleClicked;
            circle.OnCircleDestroyed += HandleCircleDestroyed;
        }

        private void HandleCircleDestroyed(Circle circle)
        {
            circle.OnCircleDestroyed -= HandleCircleDestroyed;

            RemoveCircle(circle);
            circle.DestroySelf();
        }

        private void HandleCircleClicked(Circle circle)
        {
            circle.OnCircleClicked -= HandleCircleClicked;

            OnCircleClicked?.Invoke(circle);

            RemoveCircle(circle);
            circle.DestroySelf();
        }

        public void RemoveCircle(Circle circle)
        {
            _circles.Remove(circle);
        }

        public void DestroyAllCircles()
        {
            foreach (var circle in _circles)
            {
                circle.OnCircleDestroyed -= HandleCircleDestroyed;
                circle.DestroySelf();
            }

            _circles.Clear();
        }
    }
}