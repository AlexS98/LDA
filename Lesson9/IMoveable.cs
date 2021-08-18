using System.Numerics;

namespace Lesson9
{
    public interface IMoveable : IPositionHolder
    {
        float Speed { get; set; }
        void Move(Vector3 newPosition);
    }
}
