using JetBrains.Annotations;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    // Parent object - to avoid long parent.parent...
    public GameObject parentToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            //TODO Animation on death, add delay as second parameter to Destroy
            Destroy(parentToDestroy);
        }
        

    }


}
