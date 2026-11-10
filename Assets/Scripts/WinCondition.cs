using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WinCondition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject winPanel;
    public GameObject losePanel;

    public int totalEnemigos = 0;
    public int enemigosMuertos;
    //public TextMeshProUGUI Enemytext;

    void Start()
    {
 
        totalEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        //Enemytext.text = (enemigosMuertos + "/" + totalEnemigos);
    }

    /*

    void Update()
    {
        Enemytext.text = (enemigosMuertos + "/" + totalEnemigos);
        if (enemigosMuertos >= totalEnemigos)
           {
            Time.timeScale = 0f;
             winPanel.SetActive(true);

           }
    }
       
    public void AddOne()
    {
        enemigosMuertos = enemigosMuertos + 1;
    }

    */
}
