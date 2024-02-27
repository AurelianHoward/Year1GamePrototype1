using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    float CurrentHealth;

    public Slider healthSlider;

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        if (CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
    }

    public void Hit(float rawDamage)
    {
        CurrentHealth -= rawDamage;
        SetHealthSlider();

        Debug.Log("OUCH: " + CurrentHealth.ToString());

        if (CurrentHealth <= 0)
        {
            Debug.Log("TODO: GAME OVER - YOU DIED");
        }
    }

    void SetHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = NormalisedHitPoints();
        }
    }

    float NormalisedHitPoints()
    {
        return CurrentHealth / maxHealth;
    }
    public void Heal (float rawDamage)
    {
        CurrentHealth += rawDamage;
        SetHealthSlider();

        Debug.Log("Yay: " + CurrentHealth.ToString());

        if (CurrentHealth <= 0)
        {
            Debug.Log("TODO: GAME OVER - YOU DIED");
        }
    }
}