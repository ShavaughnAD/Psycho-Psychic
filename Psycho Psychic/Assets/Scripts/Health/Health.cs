using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 0;
    public float currentHealth = 0;
    public float damageTaken = 0;
    public float healingRecieved = 0;

    public GameObject popup;
    bool invulnerable = false;
    public bool immune { get => invulnerable; set => invulnerable = value; }

    public HealthDelegate onHurt = new HealthDelegate();
    public HealthDelegate onDeath = new HealthDelegate();
    public HealthDelegate onHeal = new HealthDelegate();

    protected void Awake()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(float damageAmount)
    {
        if (immune) return;
        if (currentHealth <= 0) return;
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        Debug.LogError(gameObject.name + " Took " + damageAmount + "  Damage");
        if (popup != null)
        {
            ShowFloatingText();
        }
        if (currentHealth == 0)
        {
            onDeath.CallEvent(0);
        }
        else
        {
            damageTaken = damageAmount;
            onHurt.CallEvent(currentHealth / maxHealth);
        }
        
            
    }

    public virtual void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void Healing(float healingAmount)
    {
        healingRecieved = healingAmount;
        onHeal.CallEvent(0);
        currentHealth += healingAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(popup, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damageTaken.ToString();
    }
}