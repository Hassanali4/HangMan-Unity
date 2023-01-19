using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonClick : MonoBehaviour
{   
    public void OnButtonclick()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
