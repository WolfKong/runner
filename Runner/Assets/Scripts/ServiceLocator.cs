using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private ServiceLocator() { }

    private readonly Dictionary<string, MonoBehaviour> services = new Dictionary<string, MonoBehaviour>();

    public static ServiceLocator Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        Register<RestAPI>();
        // Register<SceneLoader>();
    }

    /// <summary>
    /// Gets the service instance of the given type.
    /// </summary>
    /// <typeparam name="T">The type of the service to lookup.</typeparam>
    /// <returns>The service instance.</returns>
    public T Get<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        return (T)services[key];
    }

    /// <summary>
    /// Registers the service with the current service locator.
    /// </summary>
    /// <typeparam name="T">Service type.</typeparam>
    /// <param name="service">Service instance.</param>
    public void Register<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (services.ContainsKey(key))
        {
            Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
            return;
        }

        var component = gameObject.AddComponent<T>();
        services.Add(key, component);
    }

    /// <summary>
    /// Unregisters the service from the current service locator.
    /// </summary>
    /// <typeparam name="T">Service type.</typeparam>
    public void Unregister<T>() where T : MonoBehaviour
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        var component = GetComponent<T>();
        Destroy(component);
        services.Remove(key);
    }
}