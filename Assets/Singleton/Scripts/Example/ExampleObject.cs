using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleObject : SingletonPattern<ExampleObject>
{
    #region Inspector Variables
    [Header("Example Object")]
    [SerializeField] private string _thisInstanceID;
    #endregion

    #region Methods
    protected override void Awake()
    {
        //Modify _createIfNull, _onlyDestroyScript, _destroyIfNotThis and _dontDestroyOnLoad here
        //_createIfNull = false;
        //_onlyDestroyScript = true;
        _destroyIfNotThis = false;
        //_dontDestroyOnLoad = true;

        //Calls the SingletonPattern virtual Awake()
        base.Awake();

        _thisInstanceID = GetInstanceID().ToString();
    }
    #endregion
}


