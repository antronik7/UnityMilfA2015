using UnityEngine;
using System.Collections;

public class SpriteFlash : MonoBehaviour 
{
    public SpriteRenderer Sprite;

	void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    public void StartFlashing()
    {
        StartCoroutine(MaCoroutine());
    }

    IEnumerator MaCoroutine()
    {
        for (int i = 0; i < 6; i++)
        {
            Sprite.enabled = false;
            yield return new WaitForSeconds(0.2f);
            Sprite.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
}