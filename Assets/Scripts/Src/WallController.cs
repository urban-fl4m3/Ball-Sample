using System;
using UnityEngine;

namespace Src
{
    public class WallController : MonoBehaviour
    {
        [SerializeField] private Material _wallMaterial;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _failColor;

        public void SetDefaultColor()
        {
            _wallMaterial.color = _defaultColor;
        }

        public void SetFailColor()
        {
            _wallMaterial.color = _failColor;
        }

        private void OnDestroy()
        {
            _wallMaterial.color = _defaultColor;
        }
    }
}