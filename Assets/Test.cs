using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.points[0] = 6;
        SceneManager.LoadScene(1);
    }

    
}
