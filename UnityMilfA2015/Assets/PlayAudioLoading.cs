using UnityEngine;
using System.Collections;

public class PlayAudioLoading : MonoBehaviour {

    public AudioClip sonConstruction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void afterAnimationLoading()
    {
        AudioSource.PlayClipAtPoint(sonConstruction, transform.position, 1f);
    }
}
