using UnityEngine;

namespace Patterns.Singleton
{
    public class Manager : Singleton<Manager>
    {
        public void Method()
        {
            Debug.Log("Manager singleton do something");
        }
    }
}