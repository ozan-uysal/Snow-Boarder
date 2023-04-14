using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class FinishPoint : MonoBehaviour
{
    public TextMeshProUGUI label;
    FinishPoint instance;
    FunctionTimer functionTimer;
    
    
    int currentScene;
    float timer;
    void Start()
    {
        instance = this;
        label.enabled = false;
        new FunctionTimer();
    }
    void Update()
    {
        timer += Time.deltaTime; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        label.enabled = true;
         
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
        }
        

    }


}
