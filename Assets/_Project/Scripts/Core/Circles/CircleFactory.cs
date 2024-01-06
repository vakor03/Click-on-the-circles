using _Project.Scripts.Infrastructure.AssetProviders;
using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    public interface ICircleFactory
    {
        Circle Create(Vector2 position, float size, float lifetime, Color color);
    }

    public class CircleFactory : ICircleFactory
    {
        private StaticDataService _staticDataService;

        public CircleFactory(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public Circle Create(Vector2 position, float size, float lifetime, Color color)
        {
            var circleConfigSO = _staticDataService.GetCircleConfig();
            var circleAnimationConfigSO = _staticDataService.GetCircleAnimationConfig();

            Circle circle = Object.Instantiate(circleConfigSO.circlePrefab);
            circle.Initialize(color, size, lifetime, circleAnimationConfigSO);

            circle.transform.position = position;

            return circle;
        }
    }
}