using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtnController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnMouseDown()
    {
        SceneManager.LoadScene("Level1");
    }
}
