using UnityEngine;

public class Manager : Singleton<Manager>
{
    public void Method()
    {
        Debug.Log("Manager singleton do something");
    }
}
