using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    // Creating a variable to store the object to avoid expensive FindGameObject everytime
    // Keeping only Transform as we only need this object
    private Transform playerSpawn;
    public Animator animator;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = playerSpawn.transform.position;
        }
    }
    
}
