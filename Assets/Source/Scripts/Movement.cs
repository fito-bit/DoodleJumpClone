using System;
using DG.Tweening;
using UnityEngine;

namespace Source.Scripts
{
    public class Movement: MonoBehaviour
    {
        [SerializeField] private float moveSpeed=5;
        [SerializeField] private float rotTime=0.3f;
        [SerializeField] private float maxX=3;
        
        protected Rigidbody2D rb;
        private float moveX;

        void RotateSprite(Vector3 rotation)
        {
            transform.DORotate(rotation * 180, rotTime);
        }

        protected virtual void InvokePlatformSpawn()
        {
            
        }
        
        void CheckHorizontalAxis()
        {
            if (Input.acceleration.x > 0)
            {
                RotateSprite(Vector3.zero);;
            }
            else if (Input.acceleration.x < 0)
            {
                RotateSprite(Vector3.up);
            }
        }
        
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }
        
        private void Update()
        {
            moveX = Input.acceleration.x*moveSpeed;
            CheckHorizontalAxis();
            if(Math.Abs(Math.Abs(transform.position.x) - maxX) < 0.5f)
            {
                if(transform.position.x>0)
                    transform.position -= Vector3.right * (maxX*2-1);
                else
                {
                    transform.position += Vector3.right * (maxX*2-1);
                }
            }
            InvokePlatformSpawn();
        }
    }
}