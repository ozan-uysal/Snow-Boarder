using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    PlayerDie instance;
    GameObject player;

    void Start()
    {
        instance = this;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.name);
        player = instance.gameObject.GetComponentInParent<Transform>().gameObject;
        Destroy(player, 3f);
        if (player == null)
        {
            Debug.Log("reload Starting");
            StartCoroutine(ReloadScene());
        } 
    }
    IEnumerator ReloadScene()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(3f);
    }

}
