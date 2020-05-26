using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    private int levelToLoadIndex;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    //Trigger the animation
    public void FadeToLevel(int _indexLevel)
    {
        levelToLoadIndex = _indexLevel;
        animator.SetTrigger("FadeOut");
    }

    //Load new scene on animation trigger (in animator)
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoadIndex);
    }
}
