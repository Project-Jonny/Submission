using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAni : MonoBehaviour
{
    public void OnCompleteAni()
    {
        Destroy(gameObject);
    }
}
