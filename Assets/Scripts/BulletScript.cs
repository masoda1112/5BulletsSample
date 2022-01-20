using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed;
    public int power;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        rigid = this.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(speed, speed);
        rigid.AddForce(new Vector2(1000, 1000));
    }

    public void Setting(int bulletLevel){
        power = bulletLevel;
        // Debug.Log(power);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
