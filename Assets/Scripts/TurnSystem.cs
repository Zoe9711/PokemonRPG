using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnSystem : MonoBehaviour
{
    [SerializeField]
    [Tooltip("scene transitions")]
    private GameManager GameManager;
    private List<UnitStats> unitsStats;
    GameObject thePlayer;
    public Button evolution;
    void Start()
    {

        unitsStats = new List<UnitStats>();
        thePlayer = GameObject.Find("pikachu");
        
        
        UnitStats playerScript = thePlayer.GetComponent<UnitStats>();
        
        print(playerScript);
        GameObject enemy = GameObject.Find("EnemyUnit");
        UnitStats enemyScript = enemy.GetComponent<UnitStats>();
        unitsStats.Add(playerScript);
        unitsStats.Add(enemyScript);
        unitsStats[0].health = GameManager.Instance.health;
        Debug.Log(unitsStats[0].health);
        unitsStats[0].healthBar.value = unitsStats[0].health;

    }



    private void Update()
    {
        Debug.Log(unitsStats[0].health);
        if(unitsStats[0].health <= 0)
        {
            GameManager.Instance.health = unitsStats[0].health;
            GameManager.loseGame();
        }
        if (unitsStats[1].health <= 0)
        {
            GameManager.Instance.health = unitsStats[0].health;
            Debug.Log(unitsStats[0].health);

            Debug.Log(GameManager.Instance.health);

            GameManager.startGame();
        }
        if (unitsStats[0].nextAttack != "")
        {
            if (unitsStats[0].nextAttack == "Tackle")
            {
                unitsStats[1].health -= unitsStats[0].attack - unitsStats[1].defense;
                unitsStats[0].nextAttack = "";
                unitsStats[1].healthBar.value = unitsStats[1].health;
                unitsStats[0].health -= unitsStats[1].attack - unitsStats[0].defense;
                unitsStats[0].healthBar.value = unitsStats[0].health;
            }
            if (unitsStats[0].nextAttack == "Thunder")
            {
                unitsStats[1].health -= unitsStats[0].magic - unitsStats[1].defense;
                unitsStats[0].nextAttack = "";
                unitsStats[1].healthBar.value = unitsStats[1].health;
                unitsStats[0].health -= unitsStats[1].attack - unitsStats[0].defense;
                unitsStats[0].healthBar.value = unitsStats[0].health;
            }
            if (unitsStats[0].nextAttack == "Evolve")
            {
                
                unitsStats[0].nextAttack = "";
                GameObject exp = Instantiate(unitsStats[0].myPrefab, thePlayer.transform.position, thePlayer.transform.rotation);
                thePlayer.GetComponent<SpriteRenderer>().sprite = unitsStats[0].evolution;
                thePlayer.GetComponent<SpriteRenderer>().flipX = true;
                unitsStats[0].evolve();
                print(unitsStats[0].attack);
                unitsStats[0].health -= unitsStats[1].attack - unitsStats[0].defense;
                unitsStats[0].healthBar.value = unitsStats[0].health;
                evolution.gameObject.SetActive(false);


            }
        }
    }

}
