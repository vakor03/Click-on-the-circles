using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    public interface ICircleFactory
    {
        Circle Create(Vector2 position, float size, float lifetime, Color color);
    }
}