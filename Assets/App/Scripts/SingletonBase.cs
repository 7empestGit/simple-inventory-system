using UnityEngine;

namespace App
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance ??= FindObjectOfType<T>();
            }
        }

        protected virtual void Awake()
        {
            EnsureSingleton();
        }

        private static void SetupInstance()
        {
            _instance = (T)FindObjectOfType(typeof(T));
            if (_instance)
                return;
            GameObject gameObj = new GameObject
            {
                name = typeof(T).Name
            };
            _instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }

        private void EnsureSingleton()
        {
            if (!_instance)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}