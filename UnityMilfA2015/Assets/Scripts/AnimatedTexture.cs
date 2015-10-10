using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour 
{
    public Vector2 Speed = Vector2.zero;

    private Vector2 Offset = Vector2.zero;
    private Material material;

	void Start () 
    {
        material = GetComponent<Renderer>().material;
        Offset = material.GetTextureOffset("_MainTex");
	}

	void Update () 
    {
        Offset += Speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", Offset);
	}
}
