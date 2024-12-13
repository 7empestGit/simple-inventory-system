using UnityEngine;

namespace App
{
    public interface IMovable
    {
        public void Move(Vector3 position, Quaternion rotation);
    }
}