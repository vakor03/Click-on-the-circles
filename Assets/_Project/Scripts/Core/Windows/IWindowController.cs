namespace _Project.Scripts.Core.Windows
{
    public interface IWindowController
    {
        void Show<T>() where T : IWindow;
        void Hide<T>() where T : IWindow;
        void Add<T>(IWindow window) where T : IWindow;
    }
}