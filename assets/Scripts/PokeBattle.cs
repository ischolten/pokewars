using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PokeBattle : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    public int playerHealth;
    public int enemyHealth;
    private int playerXP;
    private int playerGold;
    private int enemyXP;
    private int playerRank;
    private int enemyRank;
    private int enemyGold;
    private int rankDiff;
    private string username;
    private string password;
    
	public GameObject playerHealthBar;
    public GameObject enemyHealthBar;
    public Text playerHealthNum;
    public Text enemyHealthNum;
    public int enemyPoked = 0;
    public int playerPoked = 0;
	public int enemyMiss;
	public int playerMiss;
    private Texture2D myGUITexture;

	private int playerStrength;
	private int enemyStrength;
	private int playerAccuracy;
	private int enemyAccuracy;

    private Text console;
    public int hitDamage;

	private HttpReq db;


    // Use this for initialization
    void Start()
    {
        //initializing
        player = GameObject.Find("Avatar");
        enemy = GameObject.Find("Enemy");
		playerHealth = ApplicationModel.health;
        enemyHealth = EnemyModel.health;
        //enemyHealth = 100;
		playerXP = ApplicationModel.experience;
        enemyXP = EnemyModel.experience;
        //enemyXP = 100;
		playerRank = ApplicationModel.rank;
        //enemyRank = EnemyModel.rank;
        enemyRank = 2;
		playerGold = ApplicationModel.gold;
        //enemyGold = EnemyModel.gold;
        enemyGold = 300;
        rankDiff = playerRank - enemyRank;

        playerHealthBar = GameObject.Find("PlayerHealth");
        enemyHealthBar = GameObject.Find("EnemyHealth");
        playerHealthNum = GameObject.Find("PlayerHealthNum").GetComponent<Text>();
        playerHealthNum.text = playerHealth  +"";
        enemyHealthNum = GameObject.Find("EnemyHealthNum").GetComponent<Text>();
        enemyHealthNum.text = enemyHealth + "";
        enemyPoked = 0;

		playerStrength = ApplicationModel.strength;
        enemyStrength = EnemyModel.strength;
        //enemyStrength = 10;
		playerAccuracy = ApplicationModel.speed;
        enemyAccuracy = EnemyModel.speed;
        //enemyAccuracy = 10;

        console = GameObject.Find("Console").GetComponent<Text>();
        console.text = "Poke your enemy!   -->";

       // Debug.Log("Initialized!");
        if (rankDiff < 0)
        {
            Debug.Log("Enemy is of higher rank");
        }
        else
        {
            Debug.Log("Player has higher rank");
        }

        //display stats

        //start movement animations

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void pokeEnemy()
    {
		if (playerHealth > 0 && enemyHealth > 0) {

			enemyPoked = 1;

			//poke

			int hitAccuracy = (int)Random.Range (1, playerAccuracy + 5);
			hitDamage = (int)Random.Range ((int)(playerStrength / 2), playerStrength);

			if (hitAccuracy >= playerAccuracy) {
				playerMiss = 1;
				//Debug.Log ("You missed.");
			} else {
				enemyHealth -= hitDamage;
				//Debug.Log ("POKE!");
			}
           
            // enemy pokes back after player Pokes
            if (playerHealth > 0 && enemyHealth > 0)
            {
                pokePlayer();
            }
            else if (playerHealth <= 0)
            {
                //playerHealthBar.transform.localScale = new Vector3(0, enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
                //playerHealthNum.text = "0";
                endBattle(enemy);
            }
            else if (enemyHealth <= 0)
            {
                //enemyHealthBar.transform.localScale = new Vector3(0, enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
                //enemyHealthNum.text = "0";
                endBattle(player);
            }

        }

        //enemyHealthBar.transform.localScale = new Vector3((float)(enemyHealth*.01*1.44), enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
        //enemyHealthNum.text = enemyHealth + "";
    }

    public void pokePlayer()
    {
        if (playerHealth > 0 && enemyHealth > 0)
        {


			int hitAccuracy = (int)Random.Range (1, enemyAccuracy + 5);
			hitDamage = (int)Random.Range ((int)(enemyStrength / 2), enemyStrength);

			if (hitAccuracy >= enemyAccuracy) {
				enemyMiss = 1;
				//Debug.Log ("You missed.");
			} else {
				playerHealth -= hitDamage;
				//Debug.Log ("POKE!");
			}

            // check for battle end
            if (playerHealth <= 0)
            {
                //playerHealthBar.transform.localScale = new Vector3(0, playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
                //playerHealthNum.text = "0";
                endBattle(enemy);

            }
            else if (enemyHealth <= 0)
            {
                //enemyHealthBar.transform.localScale = new Vector3(0, playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
                //enemyHealthNum.text = "0";
                endBattle(player);
            }
        }
        //playerHealthBar.transform.localScale = new Vector3((float)(playerHealth * .01*1.44), playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
        //playerHealthNum.text = playerHealth + "";
    }

    void endBattle(GameObject winner)
    {

        if (winner.name.Equals(enemy.name))
        {
            myGUITexture = (Texture2D)Resources.Load("tempLoseScreen.png");
            //Debug.Log("Sorry, you lost. You lost both experience and gold.");
			console.text = "You lost. Try again! \nYou have gain 10 exp and lost " 
				+ (int)(playerGold * .05)+ "pieces of gold";
            playerXP += 10;
            playerGold -= (int)(playerGold * .05);
            
    //load lose screen
}
        else
        {
            myGUITexture = (Texture2D)Resources.Load("tempWinScreen.png");
            //Debug.Log("Congratulations! You won! You have gained both experience and gold!");
			console.text = "You lost. Try again! \nYou have gain 30 exp and lost " 
				+ (int)((enemyGold * .05) + 50 )+ "pieces of gold";
            playerGold += (int)(enemyGold * .05) + 50;
            playerXP += 30;
			EnemyModel.npcNum--;
            if ((int)(playerXP / 100) > playerRank)
            {
                Debug.Log("Congratulations! You have leveled up!");
                playerRank += 1;
				ApplicationModel.speed += 25;
				ApplicationModel.strength += 25;
				ApplicationModel.health += 25;
            }
            //load win screen
        }

		ApplicationModel.experience = playerXP;
		ApplicationModel.gold = playerGold;
		ApplicationModel.rank = playerRank;
		StartCoroutine(updatePlayer ());
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Profile");
    }

        //save all stats back into database

	public IEnumerator updatePlayer() {
		db = GameObject.Find ("HttpReq").GetComponentInChildren<HttpReq> ();
		WWW results = db.GET ("70.46.202.195/pokewars/index.php/main/process/%7B%22command%22:%22update%22,%22id%22:%22"
			+ ApplicationModel.id +"%22,%22experience%22:%22" + ApplicationModel.experience +
			"%22,%22gold%22:%22" + ApplicationModel.gold +
			"%22,%22health%22:%22" + ApplicationModel.health +
			"%22,%22strength%22:%22" + ApplicationModel.strength +
			"%22,%22speed%22:%22" + ApplicationModel.speed + "%22%7D");
		yield return results;
		Debug.Log (results.text);
	}    

}