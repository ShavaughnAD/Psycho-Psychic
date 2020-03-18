using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class PlayerDeathController : MonoBehaviour
{
    Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        health.onHurt.BindToEvent(Heal);
        health.onDeath.BindToEvent(Death);
    }

    void Heal(float param)
    {

    }

    void Death(float param)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
