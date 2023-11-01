using System;
using UnityEngine;

namespace Interfaces
{
    public abstract class IDamageable : MonoBehaviour
    {
        
        [SerializeField] protected float stunTime;
        //protected bool stunned=false;

        public float StunTime => stunTime;

        [SerializeField] protected float stunCounter;

        public float StunCounter
        {
            get => stunCounter;
            set => stunCounter = value;
        }

        protected MoveBehaviour _moveBehaviour;
        public abstract void getDMG();

        protected void Start()
        {
            _moveBehaviour = GetComponent<MoveBehaviour>();
        }
    }
}