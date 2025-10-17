using Patterns.GlobalEventSystem;
using UnityEngine;

namespace Patterns.Observer
{
    public class Listener : MonoBehaviour
    {
        [SerializeField] private Subject _subject;

        private void OnEnable()
        {
            _subject.Event += OnEvent;
        }
        private void OnDisable()
        {
            _subject.Event -= OnEvent;
        }

        private void OnEvent()
        {
            Debug.Log("Event Happened, do something");
        }
    }
}