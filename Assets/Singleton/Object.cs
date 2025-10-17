using UnityEngine;

namespace Patterns.Singleton
{
    public class Object : MonoBehaviour
    {
        private void Start()
        {
            Manager.Instance.Method();
        }
    }
}