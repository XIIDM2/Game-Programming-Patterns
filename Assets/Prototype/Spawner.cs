using UnityEngine;

namespace Patterns.Prototype
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prototypePrefab;

        private void Start()
        {
            Instantiate(_prototypePrefab);
        }
    }
}