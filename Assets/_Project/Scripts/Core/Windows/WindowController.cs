using System;
using System.Collections.Generic;

namespace _Project.Scripts.Core.Windows
{
    public class WindowController : IWindowController
    {
        private Dictionary<Type, IWindow> _windows = new();
        public void Add<T>(IWindow window) where T : IWindow
        {
            _windows.Add(typeof(T), window);
        }
        public void Show<T>() where T : IWindow
        {
            _windows[typeof(T)].Show();
        }

        public void Hide<T>() where T : IWindow
        {
            _windows[typeof(T)].Hide();
        }
    }
}