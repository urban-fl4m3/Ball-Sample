using System;
using UnityEngine;

namespace Src
{
    public class PlayerBall : MonoBehaviour, ICollidable
    {
        public event Action<bool> TargetReached;
        // public event Action TurnCompleted;
        
        [SerializeField] private float _time;
        
        private bool _isMoving;

        private Vector3 _startMovePosition;
        private Vector3 _endMovePosition;
        private float _moveTime;
        
        public void StartMove(Vector3 to)
        {
            _startMovePosition = transform.position;
            _endMovePosition = to;
            _moveTime = 0.0f;
            _isMoving = true;
        }

        public void ResetPositions(Vector3 position)
        {
            transform.position = position;
        }

        public void Stop()
        {
            _isMoving = false;
            _moveTime = 0.0f;
            _endMovePosition = transform.position;
        }

        public void CollideWithResult(bool result)
        {
            TargetReached?.Invoke(result);
        }

        private void Update()
        {
            if (_isMoving)
            {
                _moveTime += Time.deltaTime;
                var lerpFactor = _time == .0f? 1 : Mathf.Clamp01(_moveTime / _time);
                
                transform.position = Vector3.Lerp(_startMovePosition, _endMovePosition, lerpFactor);
                
                if (_moveTime >= _time)
                {
                    _isMoving = false;
                    _moveTime = 0.0f;
                    
                    // TurnCompleted?.Invoke();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //or work with layers: 1 << other.gameObject.layer == _collisionLayerMask(Wall/Target)
            //i prefer this collision check, cause it's easier to extend
            if (other.TryGetComponent<IObstacle>(out var obstacle))
            {
                obstacle.CollideWith(this);
            }
        }
    }
}