using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // 動く速さを決める
    [SerializeField] float speed;

    // 移動先と移動ポイントを決める
    [SerializeField] float endPos; // ここまで
    [SerializeField] float movePos; // ここに移動

    // 約0.02秒ごとに呼ばれる関数
    void Update()
    {
        transform.Translate(0, speed, 0);

        // endPosまできたらmovePosに移動させる
        if (transform.position.y < endPos)
        {
            transform.position = new Vector3(0, movePos, 0);
        }
    }
}
