using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public Text timeText;
    public Text resultText;
    public Text retryText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = Time.timeSinceLevelLoad.ToString();
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("MainScene");
        }
    }

    public void GameOver(){
        Time.timeScale = 0;
        resultText.text = "Lose...";
        resultText.text = "Hit SPACE to replay！";
    }

    public void GameClear(){
        Time.timeScale = 0;
        resultText.text = "Win!!!";
        resultText.text = "Hit SPACE to replay！";
    }
}
