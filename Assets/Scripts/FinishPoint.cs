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
    [SerializeField] ParticleSystem finishEffect;
    
    bool collided = false;
    int currentScene;
    float timer=3f;
    void Start()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        label.enabled = true;
        collided = true;
        Debug.Log("You did well :). Reload starting!!!");
        
        if(other.tag == "Player")
        {
            finishEffect.Play();
            StartCoroutine(WaitReloadScene());
        }
    }
    IEnumerator WaitReloadScene()
    {
        yield return new WaitForSeconds(timer);

        if (collided)
        {
            
            ReloadScene();
        }
    }
    public void ReloadScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
