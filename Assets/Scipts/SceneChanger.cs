using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] string nameScene;
 
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nameScene);
        }
        //Input.anyKeyDown
    }
}
