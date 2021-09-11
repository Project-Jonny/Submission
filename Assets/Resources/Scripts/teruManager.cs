using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teruManager : MonoBehaviour
{
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;
    Rigidbody2D rb;

    SpriteRenderer sp;

    float speed;

    GameObject player;

    // 弾のprefab
    [SerializeField] BossBullet[] bulletPref = default;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = DIRECTION_TYPE.STOP;

        player = GameObject.Find("player");

        StartCoroutine(CPU());
    }

    void Update()
    {
        if (transform.position.x < -2)
        {
            direction = DIRECTION_TYPE.RIGHT;
        }
        else if (transform.position.x > 2)
        {
            direction = DIRECTION_TYPE.LEFT;
        }
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;

            case DIRECTION_TYPE.RIGHT:
                transform.localScale = new Vector3(-1, 1, 1);
                speed = 2;
                break;

            case DIRECTION_TYPE.LEFT:
                transform.localScale = new Vector3(1, 1, 1);
                speed = -2;
                break;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Shot(float angle, float speed, int pref)
    {
        // Bossの弾
        BossBullet bullet = Instantiate(bulletPref[pref], transform.position, transform.rotation);
        bullet.Setting(angle, speed);
    }

    IEnumerator CPU()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            int r = Random.Range(0, 7);
            switch (r)
            {
                case 0:
                    yield return WaveNShotM(4, 32);
                    yield return new WaitForSeconds(1);
                    break;
                case 1:
                    direction = DIRECTION_TYPE.STOP;
                    yield return WaveNShotMCurve(2, 32);
                    yield return new WaitForSeconds(3);
                    break;
                case 2:
                    yield return WaveNPlayerAimShot(3, 5);
                    yield return new WaitForSeconds(1);
                    break;
                case 3:
                    direction = DIRECTION_TYPE.STOP;
                    yield return WaveNPlayerAimShotSolo(32, 5);
                    yield return new WaitForSeconds(3);
                    break;
                case 4:
                    direction = DIRECTION_TYPE.STOP;
                    yield return WaveNShotMCurveRound(1, 32);
                    yield return new WaitForSeconds(1);
                    break;
                case 5:
                    direction = DIRECTION_TYPE.STOP;
                    yield return WaveNShotMCurveRev(1, 32);
                    yield return new WaitForSeconds(1);
                    break;
                case 6:
                    yield return WaveNShotMCurveAim(3, 8);
                    yield return new WaitForSeconds(1);
                    break;
            }
            direction = DIRECTION_TYPE.RIGHT;
        }
    }

    IEnumerator WaveNShotM(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(m, 3);
        }
    }

    // ハート型
    IEnumerator WaveNShotMCurve(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(m, 3);
        }
    }

    // ぐるぐる
    IEnumerator WaveNShotMCurveRound(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurveRound(m, 3);
        }
    }

    // 自機狙いぐるぐる
    IEnumerator WaveNShotMCurveAim(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return PlayerAimShotRound(m, 3, 1);
        }
    }

    // 逆ぐるぐる
    IEnumerator WaveNShotMCurveRev(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurveRev(m, 3);
        }
    }

    // 複数タイプ
    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.3f);
            PlayerAimShot(m, 3, 3);
        }
    }

    // ソロタイプ
    IEnumerator WaveNPlayerAimShotSolo(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(0.05f);
            PlayerAimShot(m, 5, 3);
        }
    }

    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360
            Shot(angle, speed, 0);
        }
    }

    // ハート型
    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360
            Shot(angle - Mathf.PI / 2, speed, 1);
            Shot(-angle - Mathf.PI / 2, speed, 1);
            Shot(angle - Mathf.PI, speed, 1);
            Shot(-angle - Mathf.PI, speed, 1);

            Shot(angle + Mathf.PI / 2, speed, 1);
            Shot(-angle + Mathf.PI / 2, speed, 1);
            Shot(angle, speed, 1);
            Shot(-angle, speed, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // ぐるぐる
    IEnumerator ShotNCurveRound(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360
            Shot(angle - Mathf.PI / 2, speed, 2);
            Shot(angle - Mathf.PI, speed, 2);

            Shot(angle + Mathf.PI / 2, speed, 2);
            Shot(angle, speed, 2);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // 逆ぐるぐる
    IEnumerator ShotNCurveRev(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // 2PI:360
            Shot(-angle - Mathf.PI / 2, speed, 2);
            Shot(-angle - Mathf.PI, speed, 2);

            Shot(-angle + Mathf.PI / 2, speed, 2);
            Shot(-angle, speed, 2);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // 自機狙い
    void PlayerAimShot(int count, float speed, int num)
    {
        if (player != null)
        {
            Vector3 diffPosition = player.transform.position - transform.position;
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2) * ((Mathf.PI / 4f) / bulletCount); // PI/2f:90
                Shot(angleP + angle, speed, num);
            }
        }
        else
        {
            Vector3 diffPosition = new Vector3(0, 0, 0);
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);
            //Shot(angleP, speed, 3);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2) * ((Mathf.PI / 4f) / bulletCount); // PI/2f:90
                Shot(angleP + angle, speed, num);
            }
        }
    }

    // 自機狙い大量
    IEnumerator PlayerAimShotRound(int count, float speed, int num)
    {
        if (player != null)
        {
            Vector3 diffPosition = player.transform.position - transform.position;
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                //float angle = i * (2 * Mathf.PI / bulletCount);
                float angle = (i - bulletCount / 2) * ((Mathf.PI / 4f) / bulletCount); // PI/2f:90
                Shot(angleP + angle - Mathf.PI / 2, speed, 1);
                Shot(angleP + -angle - Mathf.PI / 2, speed, 1);
                Shot(angleP + angle - Mathf.PI, speed, 1);
                Shot(angleP + -angle - Mathf.PI, speed, 1);

                Shot(angleP + angle + Mathf.PI / 2, speed, 1);
                Shot(angleP + -angle + Mathf.PI / 2, speed, 1);
                Shot(angleP + angle, speed, 1);
                Shot(angleP + -angle, speed, 1);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            Vector3 diffPosition = new Vector3(0, 0, 0);
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            int bulletCount = count;
            for (int i = 0; i < bulletCount; i++)
            {
                //float angle = (i - bulletCount / 2) * ((Mathf.PI / 4f) / bulletCount); // PI/2f:90
                float angle = i * (2 * Mathf.PI / bulletCount);
                Shot(angleP + angle, speed, num);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator Flash()
    {
        int count = 0;
        while (count < 20)
        {
            // 消える
            sp.color = new Color(1f, 1f, 1f, 0.6f);
            yield return new WaitForSeconds(0.05f); // 0.1秒まて
            // つく
            sp.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.05f); // 0.1秒まて
            count++;
        }
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Flash());
        }
    }
}
