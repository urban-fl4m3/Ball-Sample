using UnityEngine;

namespace Src
{
    public class TargetBall : MonoBehaviour, IObstacle
    {
        public void CollideWith(ICollidable collidable)
        {
            collidable.CollideWithResult(true);
        }
    }
}