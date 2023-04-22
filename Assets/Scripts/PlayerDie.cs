using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("dead bcs of this : " + other.name+ " hits to brain :)");
        

        PlayerDieMethod();
        Debug.Log("reload Starting");
        Invoke("ReloadScene",3);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void PlayerDieMethod()
    {
        player.SetActive(false);
    }
 

}
