using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public int strength = 10;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint = 0;

    public SpriteRenderer spriteRenderer;


    void Start()
    {
        target = waypoints[0];
        spriteRenderer.flipX = true;
    }

    void Update()
    {

        Vector3 dir = target.position - transform.position;
        //Movement - normalizing vector * speed * time (along
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // If enemy is almost arrived to position
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(strength);
        }
    }


}
