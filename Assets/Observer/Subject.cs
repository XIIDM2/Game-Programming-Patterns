using UnityEngine;
using UnityEngine.Events;

namespace Patterns.GlobalEventSystem
{
    public class Subject : MonoBehaviour
    {
        public event UnityAction Event;

        private float _timer = 5;

        private bool _happened = false;

        private void Start()
        {
            Event?.Invoke();
        }

        private void Update()
        {
            if (Time.time > _timer && !_happened)
            {
                _happened = true;
                Messenger.Broadcast(GameEvents.GlobalEvent);
            }
        }
    }
}