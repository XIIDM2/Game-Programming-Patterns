using UnityEngine;

namespace Patterns.FSM
{
    public class PlayerAnimatiion : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBoolParameter(string name, bool value)
        {
           // _animator.SetBool(name, value);
        }

        public void SetTriggerParameter(string name)
        {
           // _animator.SetTrigger(name);
        }
    }
}