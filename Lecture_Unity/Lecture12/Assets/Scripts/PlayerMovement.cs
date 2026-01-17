using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed = 2.0f;

        private Rigidbody _palyerRb;

        private void Awake()
        {
            _palyerRb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MoveCharacter(Vector3 movement)
        {
            _palyerRb.AddForce(movement * _speed);
        }


#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void RsetValues()
        {
            _speed = 2f;
        }
#endif
    }
}
