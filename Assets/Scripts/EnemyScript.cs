using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public int enemyLife;
    public GameObject bullet;
    public GameObject player;
    public GameObject gameController;
    public Text enemyLifeText;
    public Text bulletLevelText;

    // Start is called before the first frame update
    void Start()
    {
        enemyLife = 50;
        enemyLifeText.text = "Life:" + enemyLife;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript playerScript = player.GetComponent<PlayerScript>();

        Destroy(collision.gameObject);
        enemyLife -= collision.gameObject.GetComponent<BulletScript>().power;
        player.GetComponent<PlayerScript>().bulletCount -= 1;
        enemyLifeText.text = "Life:" + enemyLife;

        // Hit(collision.gameObject);

        if(playerScript.bulletCount < 4){
            BulletLevelOverWriting(playerScript);
        }

        if(enemyLife <= 0){
            enemyLifeText.text = "Life:" + 0;
            gameController.GetComponent<GameControllerScript>().GameClear();
            Destroy(gameObject);
        }
    }

    // できれば下のようにしたい
    // private void Hit(GameObject object){
    //     Destroy(object);
    //     enemyLife -= object.GetComponent<BulletScript>().power;
    //     player.GetComponent<PlayerScript>().bulletCount -= 1;
    //     enemyLifeText.text = "Life:" + enemyLife;
    // }

    private void BulletLevelOverWriting(PlayerScript playerScript){
        playerScript.bulletLevel -= 1;
        bulletLevelText.text = "BulletLevel:" + playerScript.bulletLevel;
    }

    private void Destroyed(){
        enemyLifeText.text = "Life:" + 0;
        gameController.GetComponent<GameControllerScript>().GameClear();
        Destroy(gameObject);
    }
}
