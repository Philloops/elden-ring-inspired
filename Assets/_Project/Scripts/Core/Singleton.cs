using UnityEngine;

namespace Nu11ity
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static volatile T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("instance not set!");
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if(instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
