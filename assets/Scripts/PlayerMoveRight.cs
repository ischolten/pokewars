using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMoveRight : MonoBehaviour {
    GameObject player;
    GameObject enemy;
    Vector3 startPosition;
    public int poked;
    int forward;
    int backward;
    GameObject button;
    GameObject mainCamera;
    public int finishedPlayerPoke = 0;
    public Text console;
    private int forConsoleMiss;
    int hitDamage;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Avatar");
        enemy = GameObject.Find("Enemy");
        mainCamera = GameObject.Find("Main Camera");
        startPosition = player.transform.position;
        poked = 0;
        forward = 0;
        backward = 0;
        button = GameObject.Find("Enemy");
        finishedPlayerPoke = 0;
        console = GameObject.Find("Console").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update() {
		if (mainCamera.GetComponent<PokeBattle>().enemyPoked == 1) { 
            if (player.transform.position.x < enemy.transform.position.x)
            {
				if (mainCamera.GetComponent<PokeBattle> ().playerMiss == 1) {
					player.transform.Translate (new Vector3 ((float)1, (float).75, 0) * 8f * Time.deltaTime);
                    forConsoleMiss = 1;
				} else {
					player.transform.Translate (new Vector3 (1, 0, 0) * 8f * Time.deltaTime);
                    forConsoleMiss = 0;
				}
            } else if (player.transform.position.x >= enemy.transform.position.x )
            {
                player.transform.position = startPosition;
                mainCamera.GetComponent<PokeBattle>().enemyPoked = 0;
				mainCamera.GetComponent<PokeBattle>().playerMiss = 0;
                poked = 1;
                if(forConsoleMiss == 1)
                {
                    console.text = "You tried to poke the enemy and missed.";
                } else
                {
                    hitDamage = mainCamera.GetComponent<PokeBattle>().hitDamage;
                    console.text = ("You poked the enemy. They recieve " + hitDamage + " points of damage to their health.");
                }
            }
        }

    }
}
