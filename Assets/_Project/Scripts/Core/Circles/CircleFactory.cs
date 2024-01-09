using _Project.Scripts.Infrastructure.AssetProviders;
using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    public class CircleFactory : ICircleFactory
    {
        private StaticDataService _staticDataService;
        private CirclesHolder _circlesHolder;

        public CircleFactory(StaticDataService staticDataService, 
            CirclesHolder circlesHolder)
        {
            _staticDataService = staticDataService;
            _circlesHolder = circlesHolder;
        }

        public Circle Create(Vector2 position, float size, float lifetime, Color color)
        {
            var circleConfigSO = _staticDataService.GetCircleConfig();
            var circleAnimationConfigSO = _staticDataService.GetCircleAnimationConfig();

            Circle circle = Object.Instantiate(circleConfigSO.circlePrefab);
            circle.Initialize(color, size, lifetime, circleAnimationConfigSO);

            circle.transform.position = position;

            _circlesHolder.AddCircle(circle);
            
            return circle;
        }
    }
}