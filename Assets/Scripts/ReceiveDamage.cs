using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using Unity.VisualScripting;

public class ReceiveDamage : MonoBehaviour
{

    public GameObject player;

    public TextMeshProUGUI healthText;
    public Image healthBar;
    public Image healthBar2;
    public int health;
    public EnemyNavigation enemyNavigation;
    //public TextMeshProUGUI enemyText;
    public NewWinCondition winconditioon;
    //public GameObject winPanel;
    //public GameObject losePanel;

    public int totalEnemigos = 0;
    public int enemigosMuertos;

    public GameObject Counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        enemyNavigation = GetComponent<EnemyNavigation>();
        totalEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //winPanel.SetActive(false);
        //losePanel.SetActive(false);
        //enemyText.text = (enemigosMuertos + "/" + totalEnemigos);


    }

    // Update is called once per frame
    void Update()
    {
        //enemyText.text = (enemigosMuertos + "/" + totalEnemigos);
        /*if (enemigosMuertos >= totalEnemigos)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);

        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Received damage from projectile!");

            Destroy(other.gameObject);

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
                enemigosMuertos = enemigosMuertos + 1;
                //Instantiate(Counter);
                


            }

        }



    }


}
