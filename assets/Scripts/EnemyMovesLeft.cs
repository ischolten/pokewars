using UnityEngine;
using System.Collections;

public class EnemyMovesLeft : MonoBehaviour {
    GameObject player;
    GameObject enemy;
    Vector3 startPosition;
    int poked;
    int forward;
    int backward;
    GameObject button;
    GameObject mainCamera;
    public int finishedPoke;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Avatar");
        enemy = GameObject.Find("Enemy");
        mainCamera = GameObject.Find("Main Camera");
        startPosition = enemy.transform.position;
        poked = 0;
        forward = 0;
        backward = 0;
        button = GameObject.Find("Enemy");
    }
	
	// Update is called once per frame
	void Update () {
        poked = enemy.GetComponent<PlayerMoveRight>().finishedPoke;
        Debug.Log(poked);
        if (poked == 1)
        {
            forward = 1;
        }
        if (poked == 1)
        {
            if (enemy.transform.position.x > player.transform.position.x && forward == 1)
            {
                enemy.transform.Translate(new Vector3(-1, 0, 0) * 4f * Time.deltaTime);

            }
            else if (enemy.transform.position.x <= player.transform.position.x)
            {
                enemy.transform.position = startPosition;
                poked = 0;
                enemy.GetComponent<PlayerMoveRight>().finishedPoke = 0;
            }
        }
    }
}
