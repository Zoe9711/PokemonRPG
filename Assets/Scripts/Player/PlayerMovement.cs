using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("how fast the player can move")]
    private int Speed;

    [SerializeField]
    [Tooltip("scene transitions")]
    private GameManager GameManager;

    Rigidbody2D playerRigidbody;

    [SerializeField]
    [Tooltip("player transform")]
    public Transform m_playerTransform;

    public float health;
    public float posX;
    public float posY;
    

    float xAxis;
    float yAxis;

	// Use this for initialization
	void Start () {
        NumOfEnemies = GameManager.Instance.enemies;
        for (int i = 0; i < NumOfEnemies.Length; i++)
        {
            if (NumOfEnemies[i] != 0)
            {
                Instantiate(enemies[i]);
            }
        }
        health = GameManager.Instance.health;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.transform.position = new Vector2(GameManager.Instance.posX, GameManager.Instance.posY);
    }

    // Update is called once per frame
    void Update () {

		xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        move();

	}

    

    void move() {
        Vector2 movementVector = new Vector2(xAxis, yAxis);
        playerRigidbody.velocity = movementVector * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("HellHound"))
        {
            Debug.Log(collision.gameObject.name);
            Debug.Log(enemies[2].name);


            for (int i = 0; i < enemies.Length; i++)
            {
                if ((enemies[i].name+"(Clone)") == collision.gameObject.name)
                {

                    NumOfEnemies[i] = 0;
                }
            }
            
            Debug.Log(NumOfEnemies[0]);
            Debug.Log(NumOfEnemies[1]);

            Debug.Log(NumOfEnemies[2]);

            Debug.Log(NumOfEnemies[3]);

            Debug.Log(NumOfEnemies[4]);




            GameManager.Instance.enemies = NumOfEnemies;
            Destroy(collision.gameObject);

            SaveHealth();
            SaveLocation();
            GameManager.startBattle();
        }


        if (collision.gameObject.CompareTag("Destination"))
        {

            GameManager.winGame();
        }

    }
    //Save data to global control
    public void SaveHealth()
    {
        GameManager.Instance.health = health;
        
    }
    public void SaveLocation()
    {
        GameManager.Instance.posX = playerRigidbody.position.x;
        GameManager.Instance.posY = playerRigidbody.position.y;

    }

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

    
}
