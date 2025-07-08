using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void RegisterService<T>(T service)
    {
        services[typeof(T)] = service;
        Debug.Log($"Registered service: {typeof(T).Name}");
    }

    public static T GetService<T>()
    {
        if (services.TryGetValue((typeof(T)), out object service))
        {
            return (T)service;
        }

        throw new InvalidOperationException($"Service {typeof(T).Name} not registered");
    }
}
