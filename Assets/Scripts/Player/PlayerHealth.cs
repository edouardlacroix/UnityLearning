using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvicible = false;
    public float invicibilityFlashTime = 0.2f;
    public float invicibilityTimeToRecover = 2f;
    public SpriteRenderer graphics;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }


    public void TakeDamage(int _damage)
    {
        if (!isInvicible)
        {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
        isInvicible = true;
        StartCoroutine(InvicibilityFlash());
        StartCoroutine(InvicibilityFlashTimer());
        }

    }

    // Flash alpha color from 0 to 1 as long as the player is invicible
    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashTime);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashTime);

        }

    }

    // Wait 3s before turning off invicibility
    public IEnumerator InvicibilityFlashTimer()
    {
        yield return new WaitForSeconds(invicibilityTimeToRecover);
        isInvicible = false;

    }
























}
