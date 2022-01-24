using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int bulletLevel;
    public GameObject bullet;
    public GameObject gameController;
    public Text bulletLevelText;
    public int bulletCount;

    // Start is called before the first frame update
    void Start()
    {
        bulletLevel = 1;
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
            Shoot();
	    }

        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("MainScene");
        }
    }

    private void Shoot(){
            GameObject shot = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 3, 0f), transform.rotation);
            shot.GetComponent<BulletScript>().Setting(bulletLevel);
            bulletCount += 1;
            settingBulletColor(shot);
            if(bulletCount < 5){
                bulletLevel += 1;
                updateBulletLevelText();
            }
    }

    public void settingBulletColor(GameObject shot){
        Renderer shotRenderer = shot.GetComponent<Renderer>();
        if(bulletLevel == 1){
            shotRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }else if(bulletLevel == 2){
            shotRenderer.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }else if(bulletLevel == 3){
            shotRenderer.material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }else if(bulletLevel == 4){
            shotRenderer.material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }else if(bulletLevel == 5){
            shotRenderer.material.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        }
    }

    public void updateBulletLevelText(){
        bulletLevelText.text = "BulletLevel:" + bulletLevel;
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Destroy(collision.gameObject);
        gameController.GetComponent<GameControllerScript>().GameOver();

    }
}
