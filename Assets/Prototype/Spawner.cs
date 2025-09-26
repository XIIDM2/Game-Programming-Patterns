using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prototypePrefab;

    private void Start()
    {
        Instantiate(_prototypePrefab);
    }
}
