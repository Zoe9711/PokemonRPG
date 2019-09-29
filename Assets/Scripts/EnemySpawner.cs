using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject[] enemies;
    public int[] NumOfEnemies;

    //void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        Instance = this;
    //    }
    //    else if (Instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        NumOfEnemies = GameManager.Instance.enemies;
        for (int i = 0; i < NumOfEnemies.Length; i++)
        {
            if (NumOfEnemies[i] != 0)
            {
                Instantiate(enemies[i]);
            }
        }

        
    }

}
