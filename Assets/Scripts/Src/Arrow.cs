using UnityEngine;

namespace Src
{
    public class Arrow : MonoBehaviour
    {
        private float _length;
        private Vector3 _direction;
        
        public void Draw(Vector3 origin, Vector3 from, Vector3 to)
        {
            var arrowTransform = transform;
            var arrowDiff = to - from;
            var arrowScale = arrowTransform.localScale;

            _direction = arrowDiff.normalized;
            _length = arrowDiff.magnitude;
            
            var angle = Vector3.SignedAngle(Vector3.right, _direction, Vector3.forward);
            
            arrowTransform.position = GetHalfLengthOffset(origin);
            arrowTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arrowTransform.localScale = new Vector3(_length, arrowScale.y, arrowScale.z);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public bool IsEnabled()
        {
            return gameObject.activeSelf;
        }
        
        public Vector3 GetEndPoint()
        {
            return GetHalfLengthOffset(transform.position);
        }

        private Vector3 GetHalfLengthOffset(Vector3 origin)
        {
            return origin + _direction * (_length * 0.5f);
        }
    }
}