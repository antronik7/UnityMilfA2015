using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("changerScene", 5);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void changerScene()
    {
        Application.LoadLevel("SceneMathieu");
    }
}
