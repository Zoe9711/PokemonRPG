using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitStats : MonoBehaviour
{
    public Sprite evolution;
    public GameObject myPrefab;
    public Slider healthBar;
    public float health = GameManager.Instance.health;
    public float mana;
    public float attack;
    public float magic;
    public float defense;
    public String nextAttack = "";
    private bool dead = false;


    public void evolve()
    {
        health *= 2;
        healthBar.maxValue *= 2;
        healthBar.value *= 2;
        attack *= 2;
        defense *= 2;
        magic *= 2;

    }

    public bool isDead()
    {
        return this.dead;
    }

}

