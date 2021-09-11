using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] GameObject Exani = default;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.position += new Vector3(0, 3f, 0)*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            GameManager.instance.AddScore();
            Instantiate(Exani, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
