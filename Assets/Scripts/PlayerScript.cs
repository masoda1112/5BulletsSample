using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int bulletLevel;
    public GameObject bullet;
    public Text resultText;
    public Text retryText;
    public Text bulletLevelText;
    public int bulletCount;

    // Start is called before the first frame update
    void Start()
    {
        bulletLevel = 1;
        Time.timeScale = 1.0f;
        updateBulletLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + dx, -45, 45),
            transform.position.y,
            0
        );

        if(Input.GetKeyDown(KeyCode.Return)) {
            GameObject shot = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 3, 0f), transform.rotation);
            shot.GetComponent<BulletScript>().Setting(bulletLevel);
            bulletCount += 1;
            settingBulletColor(shot);
            if(bulletCount < 5){
                bulletLevel += 1;
                updateBulletLevelText();
            }
	    }

        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("MainScene");
        }
    }

    public void settingBulletColor(GameObject shot){
        if(bulletLevel == 1){
            shot.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }else if(bulletLevel == 2){
            shot.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }else if(bulletLevel == 3){
            shot.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }else if(bulletLevel == 4){
            shot.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }else if(bulletLevel == 5){
            shot.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        }
    }

    public void updateBulletLevelText(){
        bulletLevelText.text = "BulletLevel:" + bulletLevel;
    }
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Destroy(collision.gameObject);
        resultText.text = "Lose...";
        resultText.text = "Hit SPACE to replay！";
        Time.timeScale = 0;
    }
}
