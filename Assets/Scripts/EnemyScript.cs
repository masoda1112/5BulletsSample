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
    public Text resultText;
    public Text retryText;
    public Text enemyLifeText;
    public Text bulletLevelText;

    // Start is called before the first frame update
    void Start()
    {
        enemyLife = 5;
        enemyLifeText.text = "Life:" + enemyLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("MainScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        enemyLife -= collision.gameObject.GetComponent<BulletScript>().power;
        enemyLifeText.text = "Life:" + enemyLife;
        player.GetComponent<PlayerScript>().bulletLevel -= 1;
        bulletLevelText.text = "BulletLevel:" + player.GetComponent<PlayerScript>().bulletLevel;
        if(enemyLife <= 0){
            enemyLifeText.text = "Life:" + 0;
            Destroy(gameObject);
            resultText.text = "Win!!!";
            resultText.text = "Hit SPACE to replay！";
            Time.timeScale = 0;
        }
    }
}
