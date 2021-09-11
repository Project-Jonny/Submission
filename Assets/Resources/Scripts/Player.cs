using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject flowerPrefab;

    void Update()
    {
        Shot();
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -2.5f, 2.5f),
            Mathf.Clamp(nextPosition.y, -4.8f, 0.5f),
            nextPosition.z
        );
        transform.position = nextPosition;
    }

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(flowerPrefab, Firepoint.position, transform.rotation);
        }
    }
}
