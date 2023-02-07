using UnityEngine;

//T allow us to assign the type of this class from a child class
public abstract class SingletonPattern<T> : MonoBehaviour where T : SingletonPattern<T>
{
    #region Inspector Variables
    [Header("Singleton")]
    [Tooltip("Set it true if you want to preserve this object during scene loading")]
    [SerializeField] protected bool _dontDestroyOnLoad = false;
    #endregion

    #region Private Variables
    //This must be static, unchanging
    private static T _instance;

    //If you want to change this values from a child class do it before calling base.Awake();
    protected static bool _createIfNull = true;
    protected static bool _onlyDestroyScript = false;
    protected static bool _destroyIfNotThis = true;
    #endregion

    #region Properties (get & set)
    //Allows to access this class instance from other classes

    //Using the get function you can look for this object in the current 
    //scene or create a new one if it doens't exists
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //Looks for an object in the scene that contains a script of 'T' type
                _instance = FindObjectOfType<T>();

                //If there isn't a instance in the scene, then create it
                if (_instance == null && _createIfNull)
                {
                    GameObject newInstance = new GameObject(typeof(T).Name);
                    _instance = newInstance.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
    #endregion

    #region Methods
    //To create Awake in derived classes, use an override Awake and call base.Awake()
    protected virtual void Awake()
    {
        //Destroys this instance if there's already one
        if (_instance != null && _instance != this)
        {
            if (_destroyIfNotThis)
            {
                //You can either destory only the script instance
                if (_onlyDestroyScript) Destroy(this);
                //Or the whole game object instance
                else Destroy(gameObject);
            }

            return;
        }

        //If there ins't yet a instance, then assings this object as the current instance
        _instance = this as T;

        //Preserves an Object during scene loading
        if (_dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
    }
    #endregion
}
