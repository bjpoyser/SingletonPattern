using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Current Intance of ExampleObject: {ExampleObject.Instance.name}");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
