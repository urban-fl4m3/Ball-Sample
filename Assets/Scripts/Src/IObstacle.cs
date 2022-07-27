namespace Src
{
    public interface IObstacle
    {
        void CollideWith(ICollidable collidable);
    }
}