using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour
{
    public int textureSize = 8;

    void Start()
    {
        float newWidth = Mathf.Ceil(Screen.width / (textureSize * CameraAndCollider.Scale));
        float newHeight = Mathf.Ceil(Screen.height / (textureSize * CameraAndCollider.Scale));

        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);

        transform.Translate(Vector3.up * newHeight / 3);
    }
}