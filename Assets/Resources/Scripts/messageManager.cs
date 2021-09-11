using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class messageManager : MonoBehaviour
{
    [SerializeField] private Text _text = default;
    SpriteRenderer sp;

    [SerializeField] Sprite[] teruSprite; // normal, happy, sad, mad

    void Start()
    {
        SoundManager.instance.PlayBGM("Stage");
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = teruSprite[0];

        _text.text = "";
        StartCoroutine(message());
    }

    IEnumerator message()
    {
        yield return null;
        _text.DOText("ひさしぶりだネ", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[1];
        _text.DOText("1年ぶりかナ", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[2];
        _text.DOText("忘れてナイよﾈ..？", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[0];
        _text.DOText("あ、誕生日おめでと！", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[0];
        _text.DOText("サロン入ったのも", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[1];
        _text.DOText("チョウド1年ﾏｴだネ", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[0];
        _text.DOText("simachuのおかゲで", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[1];
        _text.DOText("毎日すゴい楽しイ！", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[2];
        _text.DOText("大変なｺﾄもアッタけど", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[1];
        _text.DOText("その分イッぱい成長したｮ", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[1];
        _text.DOText("コレからもよろシくネ！", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[0];
        _text.DOText("それじャそろそろ", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[0];
        _text.DOText("げぇむをハジメよッか", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[1];
        _text.DOText("ガンバッたからホメてね", 2);
        yield return new WaitForSeconds(4f);

        _text.text = "";
        sp.sprite = teruSprite[0];
        _text.DOText("いくヨ...", 2);
        yield return new WaitForSeconds(4f);

        SoundManager.instance.PlaySE(0);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.2f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.2f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.2f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[0];
        yield return new WaitForSeconds(0.01f);
        sp.sprite = teruSprite[3];
        yield return new WaitForSeconds(0.01f);

        SceneManager.LoadScene("Main");
    }
}