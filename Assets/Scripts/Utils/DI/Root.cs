using System;
using System.Collections.Generic;

namespace SergeyPchelintsev.Expedito.Utils.DI
{
    public class Root : IRoot
    {
        private readonly Dictionary<Type, object> objects = new Dictionary<Type, object>();
        
        public void Add<T>(T obj) where T : class
        {
            Add(typeof(T), obj);
        } 
        
        public void Add<T>(Type type, T obj) where T : class
        {
            if (obj == null) return;
            objects[type] = obj;
        }

        public T Get<T>() where T : class
        {
            var type = typeof(T);
            
            return objects.ContainsKey(type) ? objects[type] as T : null;
        }
    }
}