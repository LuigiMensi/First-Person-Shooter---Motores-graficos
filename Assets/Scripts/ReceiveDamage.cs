using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using Unity.VisualScripting;

public class ReceiveDamage : MonoBehaviour
{


    public TextMeshProUGUI healthText;
    public Image healthBar;
    public Image healthBar2;
    public int health;
    public EnemyNavigation enemyNavigation;

    public WinCondition win;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        win = GetComponent<WinCondition>();
        enemyNavigation = GetComponent<EnemyNavigation>();

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Received damage from projectile!");

            Destroy(collision.gameObject);

            health -= 25;
            healthText.text =  health.ToString();

            healthBar.fillAmount = health/100f;
           
            Debug.Log("Current Health: " + health);

            if (health <= 0)
            {
                Debug.Log("Player is dead");
                enemyNavigation.Die();
                
                Destroy(healthBar);
                Destroy(healthText);
                Destroy(healthBar2);
                
            }

        }
    }


}
