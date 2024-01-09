using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    public class CircleRayhitDetector
    {
        private RaycastHit2D[] _hits = new RaycastHit2D[10];

        public Circle RayHit(Vector2 position)
        {
            var ray = Camera.main.ScreenPointToRay(position);

            Physics2D.GetRayIntersectionNonAlloc(ray, _hits);
            foreach (var hit in _hits)
            {
                if (hit.collider != null)
                {
                    var circle = hit.collider.GetComponent<Circle>();
                    if (circle != null)
                    {
                        return circle;
                    }
                }
            }

            return null;
        }
    }
}