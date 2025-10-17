using UnityEngine;

namespace Patterns.GlobalEventSystem
{
    public class SomeSystem : MonoBehaviour
    {
        private void OnEnable()
        {
            Messenger.AddListener(GameEvents.GlobalEvent, SomeMethod);
        }

        private void OnDisable()
        {
            Messenger.RemoveListener(GameEvents.GlobalEvent, SomeMethod);
        }

        private void SomeMethod()
        {
            Debug.Log("System do some logic");
        }
    }
}