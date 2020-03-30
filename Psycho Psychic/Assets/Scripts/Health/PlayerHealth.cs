using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public float maxPower = 50;
    public float currentPower = 0;

    public override void Awake()
    {
        base.Awake();
        popup = Resources.Load<GameObject>("Prefabs/HealingFloatingText");
        //onHurt.BindToEvent(Hurt);
        onHeal.BindToEvent(Heal);
        onDeath.BindToEvent(Death);
    }

    //void Hurt(float param)
    //{

    //}

    void Heal(float param)
    {
        HealingFloatingText();
    }

    void Death(float param)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
