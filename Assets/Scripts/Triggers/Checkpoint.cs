using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Transform playerSpawn;
    private SpriteRenderer spriteRenderer;
    private AudioSource sound;
  
    // Getting player spawn transform reference for optimization
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        sound = gameObject.GetComponent<AudioSource>();
    }

    // Changing player spawn position on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.transform.position = transform.position;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            spriteRenderer.color = new Color(1, 1, 1);
            sound.Play();
        }

    }
}
