using UnityEngine;
using System.Collections;

public class EnemyMovesLeft : MonoBehaviour {
    GameObject player;
    GameObject enemy;
    Vector3 startPosition;
    int forward;
    int backward;
    GameObject button;
    GameObject mainCamera;
    public int finishedEnemyPoke = 0;
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
    }
	
	// Update is called once per frame
	void Update () {
		if (mainCamera.GetComponent<PlayerMoveRight>().poked == 1)
        {
            if (enemy.transform.position.x > player.transform.position.x)
            {
				enemy.transform.Translate(new Vector3(-1, 0, 0) * 8f * Time.deltaTime);

            }
            else if (enemy.transform.position.x <= player.transform.position.x)
            {
                enemy.transform.position = startPosition;
                mainCamera.GetComponent<PlayerMoveRight>().poked = 0;
                finishedEnemyPoke = 1; 
            }
        }
    }
}
