using UnityEngine;

namespace Kivoices.Scripts.Utility
{
    /// <summary>
    /// Provides a static instance of a MonoBehaviour class. 
    /// Unlike a typical singleton, a static instance allows resetting the state by overriding
    /// with a new instance rather than keeping the original intact.
    /// </summary>
    /// <typeparam name="T">The type of the static MonoBehaviour instance.</typeparam>
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Holds the single instance of the class.
        /// </summary>
        public static T Instance { get; private set; }

        /// <summary>
        /// Initializes the static instance, overriding it with a new one if already set.
        /// </summary>
        protected virtual void Awake()
        {
            // Check if an instance does not already exist.
            if (Instance == null)
                Instance = this as T; // Set the instance to the current MonoBehaviour if none exists.
        }

        /// <summary>
        /// Resets the instance to null on application quit and destroys the game object.
        /// </summary>
        protected virtual void OnApplicationQuit()
        {
            // Reset the static instance when the application exits.
            Instance = null;
            Destroy(gameObject); // Clean up by destroying the game object.
        }
    }

    /// <summary>
    /// A basic Singleton class that ensures only one instance exists by destroying any new instances.
    /// </summary>
    /// <typeparam name="T">The type of the singleton MonoBehaviour.</typeparam>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Overrides the static instance to keep only one instance and destroy any new instance that might be created.
        /// </summary>
        protected override void Awake()
        {
            // Destroy any new instance if one already exists.
            if (Instance != null)
                Destroy(gameObject);

            // Call the base Awake method to initialize the instance.
            base.Awake();
        }
    }

    /// <summary>
    /// Persistent Singleton that persists across scenes and only allows one instance.
    /// Useful for system classes requiring state persistence or audio sources that play across scenes.
    /// </summary>
    /// <typeparam name="T">The type of the singleton MonoBehaviour.</typeparam>
    public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Ensures only one instance persists across scenes by setting it as non-destroyable.
        /// </summary>
        protected override void Awake()
        {
            // Destroy any new instance if one already exists.
            if (Instance != null)
                Destroy(gameObject);

            // Initialize the singleton instance and prevent it from being destroyed on scene load.
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }

    #region Auto-Instantiated Singleton Classes
    /// <summary>
    /// Auto-instantiated static instance for MonoBehaviour. Instantiates automatically if called 
    /// and not already present in the scene. Suitable for components needed on demand.
    /// </summary>
    /// <typeparam name="T">The type of the singleton MonoBehaviour.</typeparam>
    public abstract class Static_AutoInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// Provides a single instance of the MonoBehaviour, creating it automatically if not found.
        /// </summary>
        public static T Instance
        {
            get
            {
                // Check if an instance does not already exist.
                if (instance == null)
                {
                    // Instantiate the object from Resources folder, using its type name.
                    instance = (Instantiate(Resources.Load(typeof(T).Name)) as GameObject).GetComponent<T>();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Auto-instantiated persistent static instance for MonoBehaviour.
    /// This instance is created automatically if accessed and persists across scenes.
    /// Suitable for components required on demand across multiple scenes.
    /// </summary>
    /// <typeparam name="T">The type of the singleton MonoBehaviour.</typeparam>
    public abstract class PersistentStatic_AutoInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// Provides a single instance of the MonoBehaviour, creating it automatically if not found, and persists across scenes.
        /// </summary>
        public static T Instance
        {
            get
            {
                // Check if an instance does not already exist.
                if (instance == null)
                {
                    // Instantiate the object from Resources and prevent it from being destroyed on scene load.
                    instance = (Instantiate(Resources.Load(typeof(T).Name)) as GameObject).GetComponent<T>();
                    DontDestroyOnLoad(instance.gameObject); // Set instance to persist across scenes.
                }
                return instance;
            }
        }
    }
    #endregion
}