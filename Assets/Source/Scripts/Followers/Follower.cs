using UnityEngine;

namespace Source.Scripts
{
    public class Follower: MonoBehaviour
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected float maxDifference=5;

        protected virtual void Move()
        {
            
        }

        private void LateUpdate()
        {
            Move();
        }
    }
}