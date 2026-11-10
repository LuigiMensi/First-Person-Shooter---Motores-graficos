using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class NewWinCondition : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI texto;
    public int tiempo;
    public GameObject winPanel;
    public GameObject losePanel;

    public int totalEnemigos = 0;
    public int enemigosMuertos;



    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        texto.text = tiempo.ToString();
        totalEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
    ;
        texto.text = (enemigosMuertos + "/" + totalEnemigos);
    }

    // Update is called once per frame
    void Update()
    {
        enemigosMuertos = GameObject.FindGameObjectsWithTag("Count").Length;
        texto.text = (enemigosMuertos + "/" + totalEnemigos);

        if (enemigosMuertos>= totalEnemigos)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
        }

    }
    
    

   /* IEnumerator CuentaRegresiva()
    {
        yield return new WaitForSeconds(1);
        tiempo = tiempo - 1;
        texto.text = tiempo.ToString();

        if (tiempo > 0)
        {
            CuentaRegresiva();
        }
        else
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }

    }
   */

}
