using System.Collections;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private AudioSource sound;
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        sound = gameObject.GetComponent<AudioSource>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            //Disabling collider and sprite while playing the sound before destroying the object
            circleCollider.enabled = false;
            spriteRenderer.enabled = false;
            sound.Play();
            Inventory.instance.AddCoins(1);
            Destroy(gameObject, 1f);
        }
    }


}
