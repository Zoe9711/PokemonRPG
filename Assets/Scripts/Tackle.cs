using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : MonoBehaviour
{
    // Start is called before the first frame update
    public void setTackle()
    {
        UnitStats playerScript = transform.GetComponent<UnitStats>();
        print(playerScript.nextAttack);
        playerScript.nextAttack = "Tackle";
        print(playerScript.nextAttack);
    }
    public void setThunder()
    {
        UnitStats playerScript = transform.GetComponent<UnitStats>();
        print(playerScript.nextAttack);
        playerScript.nextAttack = "Thunder";
        print(playerScript.nextAttack);
    }
    public void setEvolution()
    {
        UnitStats playerScript = transform.GetComponent<UnitStats>();
        print(playerScript.nextAttack);
        playerScript.nextAttack = "Evolve";
        print(playerScript.nextAttack);
    }
}
