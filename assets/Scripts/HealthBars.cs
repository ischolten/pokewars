using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    private int playerHealth;
    private int enemyHealth;
    public GameObject playerHealthBar;
    public GameObject enemyHealthBar;
    public Text playerHealthNum;
    public Text enemyHealthNum;
    int enemyPoked;
    int playerPoked;
    private GameObject player;
    private GameObject enemy;
    GameObject mainCamera;



    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        playerHealth = mainCamera.GetComponent<PokeBattle>().playerHealth;
        enemyHealth = mainCamera.GetComponent<PokeBattle>().enemyHealth;
        playerHealthBar = GameObject.Find("PlayerHealth");
        enemyHealthBar = GameObject.Find("EnemyHealth");
        playerHealthNum = GameObject.Find("PlayerHealthNum").GetComponent<Text>();
        playerHealthNum.text = playerHealth + "";
        enemyHealthNum = GameObject.Find("EnemyHealthNum").GetComponent<Text>();
        enemyHealthNum.text = enemyHealth + "";

		playerHealth = playerHealth * (100 / playerHealth);
		enemyHealth = enemyHealth * (100 / enemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = mainCamera.GetComponent<PokeBattle>().playerHealth;
        enemyHealth = mainCamera.GetComponent<PokeBattle>().enemyHealth;

		playerHealth = playerHealth * (100 / playerHealth);
		enemyHealth = enemyHealth * (100 / enemyHealth);
        

		if (mainCamera.GetComponent<PlayerMoveRight> ().poked == 1) {
			if (enemyHealth <= 0) {
				enemyHealthBar.transform.localScale = new Vector3 (0, enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
				enemyHealthNum.text = "0";
			} else {
				enemyHealthBar.transform.localScale = new Vector3 ((float)(enemyHealth * .01 * 1.44), enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
				enemyHealthNum.text = enemyHealth + "";
			}

		} else if (mainCamera.GetComponent<EnemyMovesLeft> ().finishedEnemyPoke == 1) {
			if (playerHealth <= 0) {
				playerHealthBar.transform.localScale = new Vector3 (0, enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
				playerHealthNum.text = "0";
			} else {
				playerHealthBar.transform.localScale = new Vector3 ((float)(playerHealth * .01 * 1.44), playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
				playerHealthNum.text = playerHealth + "";
				mainCamera.GetComponent<EnemyMovesLeft> ().finishedEnemyPoke = 0;
			}
        }
    }
}
