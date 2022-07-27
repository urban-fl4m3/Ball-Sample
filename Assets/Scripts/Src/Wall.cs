using UnityEngine;

namespace Src
{
    public class Wall : MonoBehaviour, IObstacle
    {
        public void CollideWith(ICollidable collidable)
        {
            collidable.CollideWithResult(false);
        }
    }
}