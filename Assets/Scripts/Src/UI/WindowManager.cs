using UnityEngine;

namespace Src.UI
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameOvewView _view;

        public void ShowView(GameOverViewModel model)
        {
            _view.Init(model);
            _view.Show();
        }
    }
}