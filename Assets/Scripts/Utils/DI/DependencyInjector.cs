using System;

namespace SergeyPchelintsev.Expedito.Utils.DI
{
    public class DependencyInjector
    {
        private static Root root;
        
        public static event Action<Root> OnRootCreated;

        public static void CreateCompositionRoot()
        {
            root = new Root();
            
            OnRootCreated?.Invoke(root);
        }
        
        public static IRoot Root => root;
    }
}