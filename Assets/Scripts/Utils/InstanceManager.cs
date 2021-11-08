using System.Collections.Generic;
using System;

namespace Utils
{
    class InstanceManager{
        private static Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public static void AddInstance<T>(T instance){
            instances.Add(typeof(T), instance);
        }

        public static T GetInstance<T>(){
            return (T)instances[typeof(T)];
        }
    }
}