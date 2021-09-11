using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // 設定された方向に弾を打つ
    float dx;
    float dy;

    void Start()
    {
        // 敵の右側が0°
        // 反時計回りに角度は増える

        // 2PIが360°
        // PIが180°
        // PI/2が90°

        Destroy(gameObject, 3f);
    }

    public void Setting(float angle, float speed)
    {
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
