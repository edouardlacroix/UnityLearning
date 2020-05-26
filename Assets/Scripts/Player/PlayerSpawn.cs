using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;

        //NOT WORKING ;( need to find a way to make the character face East on respawn
        //spriteRenderer = player.GetComponent<SpriteRenderer>();
        //spriteRenderer.flipX = false;
    }
}
