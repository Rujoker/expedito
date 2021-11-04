using UnityEngine;

namespace SergeyPchelintsev.Expedito.Utils.DI
{
    public class DependencyController : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] monoBehaviours;
        [SerializeField] private ScriptableObject[] scriptableObjects;
        
        private void Awake() => DependencyInjector.OnRootCreated += AddToRoot;
        private void OnDestroy() => DependencyInjector.OnRootCreated -= AddToRoot;

        private void AddToRoot(Root root)
        {
            foreach (var behaviour in monoBehaviours)
            {
                root.Add(behaviour.GetType(), behaviour);
            }
            
            foreach (var scriptable in scriptableObjects)
            {
                root.Add(scriptable.GetType(), scriptable);
            }
        }
    }
}