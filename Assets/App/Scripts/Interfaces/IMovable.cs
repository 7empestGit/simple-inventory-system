using UnityEngine;

namespace App.Interfaces
{
    public interface IMovable
    {
        public void Move(Vector3 position, Quaternion rotation);
    }
}