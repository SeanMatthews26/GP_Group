using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
            player.GetComponent<PlayerControls>().startingPos = transform.position;
        }
    }
}
