using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMovesLeft : MonoBehaviour {
    GameObject player;
    GameObject enemy;
    Vector3 startPosition;
    int forward;
    int backward;
    GameObject button;
    GameObject mainCamera;
    public int finishedEnemyPoke = 0;
    int forConsoleMiss;
    public Text console;
    int hitDamage;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Avatar");
        enemy = GameObject.Find("Enemy");
        mainCamera = GameObject.Find("Main Camera");
        startPosition = enemy.transform.position;
        forward = 0;
        backward = 0;
        button = GameObject.Find("Enemy");
        finishedEnemyPoke = 0;
        console = GameObject.Find("Console").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		if (mainCamera.GetComponent<PokeBattle> ().enemyHealth > 0) {
			if (mainCamera.GetComponent<PlayerMoveRight> ().poked == 1) {
				if (enemy.transform.position.x > player.transform.position.x) {
					if (mainCamera.GetComponent<PokeBattle> ().enemyMiss == 1) {
						enemy.transform.Translate (new Vector3 ((float)-1, (float).75, 0) * 8f * Time.deltaTime);
                        forConsoleMiss = 1;
					} else {
						enemy.transform.Translate (new Vector3 (-1, 0, 0) * 8f * Time.deltaTime);
                        forConsoleMiss = 0;
					}

				} else if (enemy.transform.position.x <= player.transform.position.x) {
					enemy.transform.position = startPosition;
					mainCamera.GetComponent<PlayerMoveRight> ().poked = 0;
					mainCamera.GetComponent<PokeBattle> ().enemyMiss = 0;
					finishedEnemyPoke = 1;
                    if(forConsoleMiss == 1)
                    {
                        console.text = "The enemy tried to poked you but missed.";
                    } else
                    {
                        hitDamage = mainCamera.GetComponent<PokeBattle>().hitDamage;
                        console.text = "The enemy poked you. You lose " + hitDamage + " points to your health.";
                    }
				}
			}
		}
    }
}
