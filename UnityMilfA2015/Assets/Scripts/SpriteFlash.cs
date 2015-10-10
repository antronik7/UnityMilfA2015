using UnityEngine;
using System.Collections;

public class SpriteFlash : MonoBehaviour 
{
    public SpriteRenderer[] Sprites;

	void Start()
    {
        Sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void StartFlashing()
    {
        StartCoroutine(MaCoroutine());
    }

    IEnumerator MaCoroutine()
    {
        for (int i = 0; i < 10; i++)

        {
            foreach (SpriteRenderer Sprite in Sprites)
            {
                Sprite.enabled = false;
            }
            
            yield return new WaitForSeconds(0.1f);

            foreach (SpriteRenderer Sprite in Sprites)
            {
                Sprite.enabled = true;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}