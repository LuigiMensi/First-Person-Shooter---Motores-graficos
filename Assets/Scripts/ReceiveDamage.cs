using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReceiveDamage : MonoBehaviour
{


    public TextMeshProUGUI healthText;
    public Image healthBar;
    public int health;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                Destroy(gameObject);
            }

        }
    }


}
