using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMoveRight : MonoBehaviour {
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
        startPosition = player.transform.position;
        poked = 0;
        forward = 0;
        backward = 0;
        button = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update() {
        poked = mainCamera.GetComponent<PokeBattle>().enemyPoked;
        if (poked == 1)
        {
            forward = 1;
        }
        if (poked == 1) { 
            if (player.transform.position.x < enemy.transform.position.x && forward == 1)
            {
                player.transform.Translate(new Vector3(1, 0, 0) * 4f * Time.deltaTime);

            } else if (player.transform.position.x >= enemy.transform.position.x )
            {
                player.transform.position = startPosition;
                poked = 0;
                mainCamera.GetComponent<PokeBattle>().enemyPoked = 0;
                finishedPoke = 1;
            }
        }

    }
}
