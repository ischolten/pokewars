using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PokeBattle : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private int playerHealth;
    private int enemyHealth;
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
    public Button playAgain;




    // Use this for initialization
    void Start()
    {
        //initializing
        player = GameObject.Find("Avatar");
        enemy = GameObject.Find("Enemy");
        playerHealth = 100; //need to get max health from database
        enemyHealth = 100;
        playerXP = 75; //need to get XP from database
        enemyXP = (int)Random.Range(50, 100);
        playerRank = 7; //need to get rank from database
        enemyRank = (int)(enemyXP / 10);
        playerGold = 500; //need to get gold from database
        enemyGold = (int)Random.Range(0, 1000);
        rankDiff = playerRank - enemyRank;
        playerHealthBar = GameObject.Find("PlayerHealth");
        enemyHealthBar = GameObject.Find("EnemyHealth");
        playerHealthNum = GameObject.Find("PlayerHealthNum").GetComponent<Text>();
        playerHealthNum.text = playerHealth  +"";
        enemyHealthNum = GameObject.Find("EnemyHealthNum").GetComponent<Text>();
        enemyHealthNum.text = enemyHealth + "";
        Debug.Log("Initialized!");
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
        if (playerHealth > 0 && enemyHealth > 0)
        {


            //animation

            //poke

            int hit;

            if (rankDiff < 0) //enemy is of higher rank
            {
                hit = (int)Random.Range(0, 5);
                if (hit <= 1)
                {
                    Debug.Log("You missed.");
                }
                else
                {
                    enemyHealth -= hit;
                    Debug.Log("POKE!");
                }

            }
            else if (rankDiff == 0) //they are of the same rank 
            {
                hit = (int)Random.Range(0, 10);
                if (hit <= 2)
                {
                    Debug.Log("You missed.");
                }
                else
                {
                    enemyHealth -= hit;
                    Debug.Log("POKE!");
                }
            }
            else // player is of higher rank
            {
                hit = (int)Random.Range(0, 15);
                if (hit <= 2)
                {
                    Debug.Log("You missed.");
                }
                else
                {
                    enemyHealth -= hit;
                    Debug.Log("POKE!");
                }
            }
            // enemy pokes back after player Pokes
            if (playerHealth > 0 && enemyHealth > 0)
            {
                pokePlayer();
            }
            else if (playerHealth <= 0)
            {
                endBattle(enemy);
            }
            else if (enemyHealth <= 0)
            {
                enemyHealthBar.transform.localScale = new Vector3(0, enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
                enemyHealthNum.text = "0";
                endBattle(player);
            }

        }

        enemyHealthBar.transform.localScale = new Vector3((float)(enemyHealth*.01*1.44), enemyHealthBar.transform.localScale.y, enemyHealthBar.transform.localScale.z);
        enemyHealthNum.text = enemyHealth + "";
    }

    public void pokePlayer()
    {
        if (playerHealth > 0 && enemyHealth > 0)
        {


            //animation

            //poke

            int hit;

            if (rankDiff < 0) //enemy is of higher rank
            {
                hit = (int)Random.Range(0, 15);
                if (hit <= 2)
                {
                    Debug.Log("Enemy missed.");
                }
                else
                {
                    playerHealth -= hit;
                    Debug.Log("You were poked by the enemy!");
                }

            }
            else if (rankDiff == 0) //they are of the same rank 
            {
                hit = (int)Random.Range(0, 10);
                if (hit <= 2)
                {
                    Debug.Log("Enemy missed.");
                }
                else
                {
                    playerHealth -= hit;
                    Debug.Log("You were poked by the enemy!");
                }
            }
            else // player is of higher rank
            {
                hit = (int)Random.Range(0, 5);
                if (hit <= 1)
                {
                    Debug.Log("Enemy missed.");
                }
                else
                {
                    playerHealth -= hit;
                    Debug.Log("You were poked by the enemy!");
                }
            }

            // check for battle end
            if (playerHealth <= 0)
            {
                playerHealthBar.transform.localScale = new Vector3(0, playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
                playerHealthNum.text = "0";
                endBattle(enemy);

            }
            else if (enemyHealth <= 0)
            {
                endBattle(player);
            }
        }
        playerHealthBar.transform.localScale = new Vector3((float)(playerHealth * .01*1.44), playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);
        playerHealthNum.text = playerHealth + "";
    }

    void endBattle(GameObject winner)
    {
        if (winner.name.Equals(enemy.name))
        {
            Debug.Log("Sorry, you lost. You lost both experience and gold.");
            playerXP -= 15;
            playerGold -= (int)(playerGold * .05);
            //load lose screen
        }
        else
        {
            Debug.Log("Congratulations! You won! You have gained both experience and gold!");
            playerGold += (int)(enemyGold * .05) + 50;
            playerXP += 40;
            if ((int)(playerXP / 10) > playerRank)
            {
                Debug.Log("Congratulations! You have leveled up!");
                playerRank += 1;
            }
            //load win screen
        }
    }

        //save all stats back into database

        IEnumerator updateUser(int id, int experience, int strength, int health) 
    {
        string url = "70.46.202.195/pokewars/index.php/main/process/";
        string json = string.Format("{\"command\":\"update\",\"id\":\"%i\",\"experience\":\"%i\",\"strength\":\"%i\",\"health\":\"%i\"}",id, experience, strength, health);
        url += json;
        WWW www = new WWW(url);
        yield return www;
    }

    public void playBattleAgain()
    {
        GameObject button = GameObject.Find("PlayAgainButton");
        if (button.GetComponent<Button>())
        {
            Start();
        }
    }
        

}
