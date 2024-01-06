using _Project.Scripts.Core.Circles;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class Test : MonoBehaviour
    {
        private ICircleFactory _circleFactory;

        [Inject]
        private void Construct(ICircleFactory circleFactory)
        {
            _circleFactory = circleFactory;
        }

        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(1))
        //     {
        //         var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //         _circleFactory.Create(position);
        //     }
        // }
    }
}