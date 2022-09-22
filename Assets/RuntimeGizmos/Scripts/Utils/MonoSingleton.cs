using UnityEngine;

namespace GizmosHelpers
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        [SerializeField] protected bool dontDestroyLoad;

        protected static bool ApplicationQuitFlag = false;
        protected static bool IsApplicationQuitting = false;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T) FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        if (IsApplicationQuitting && Application.isPlaying)
                        {
                            return instance;
                        }

                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        singleton.name = $"{typeof(T)}";
                    }
                }

                return instance;
            }
        }

        protected void Awake()
        {
            if (instance == null)
            {
                instance = gameObject.GetComponent<T>();
                if (dontDestroyLoad)
                {
                    SetDontDestroyOnLoad();
                }

                OnAwake();
            }
            else
            {
                if (this == instance)
                {
                    if (dontDestroyLoad)
                    {
                        SetDontDestroyOnLoad();
                    }

                    OnAwake();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        protected virtual void OnAwake()
        {
        }

        public virtual void OnDisable()
        {
#if UNITY_EDITOR
            IsApplicationQuitting = ApplicationQuitFlag;
#endif
        }

        protected void SetDontDestroyOnLoad()
        {
            dontDestroyLoad = true;
            if (dontDestroyLoad)
            {
                if (transform.parent != null)
                {
                    transform.parent = null;
                }

                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// If any script calls Instance after it has been destroyed,
        /// it will create a buggy ghost object that will stay on the Editor scene
        /// even after stopping playing the Application.This will make sure the buggy ghost object
        /// is not created.
        /// </summary>
#if UNITY_EDITOR
        public virtual void OnApplicationQuit()
        {
            ApplicationQuitFlag = true;
        }
#endif
    }
}