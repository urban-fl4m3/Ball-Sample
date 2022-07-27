using Src.UI;
using UnityEngine;

namespace Src
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private Transform _startTransform;
        [SerializeField] private PlayerBall _player;
        [SerializeField] private Arrow _arrow;
        [SerializeField] private WallController _wallController;
        [SerializeField] private WindowManager _windowManager;
        
        private MouseController _mouseController;
        
        private void Start()
        {
            StartLevel();
        }

        private void OnMouseDown()
        {
            _arrow.Show();
        }

        private void OnMouseUp()
        {
            if (_arrow.IsEnabled())
            {
                var point = _arrow.GetEndPoint();
                _player.StartMove(point);
                _arrow.Hide();
            }
        }

        private void OnMouseDrag(Vector3 from, Vector3 to)
        {
            _arrow.Draw(_player.transform.position, from, to);
        }

        private void StartLevel()
        {
            _mouseController = new MouseController(_gameCamera);
            _mouseController.MousePressed += OnMouseDown;
            _mouseController.MouseUpped += OnMouseUp;
            _mouseController.MouseDragging += OnMouseDrag;
            
            _player.TargetReached += PlayerOnTargetReached;
            // _player.TurnCompleted += PlayerOnTurnCompleted;
            _player.ResetPositions(_startTransform.position);
            
            _wallController.SetDefaultColor();
        }

        private void PlayerOnTurnCompleted()
        {
            _arrow.Hide();
        }

        private void Update()
        {
            //can be swapped for bool check "IsEnabled" in controller, but with this implementation we could create
            //second type of controller and use abstraction as strategy
            _mouseController?.Update();
        }

        private void PlayerOnTargetReached(bool isTargetReached)
        {
            _mouseController.MousePressed -= OnMouseDown;
            _mouseController.MouseUpped -= OnMouseUp;
            _mouseController.MouseDragging -= OnMouseDrag;
            _player.TargetReached -= PlayerOnTargetReached;
            // _player.TurnCompleted -= PlayerOnTurnCompleted;

            _mouseController = null;
            _player.Stop();
            // _arrow.Hide();

            if (!isTargetReached)
            {
                _wallController.SetFailColor();
            }
            
            _windowManager.ShowView(new GameOverViewModel(isTargetReached, StartLevel));
        }
    }
}