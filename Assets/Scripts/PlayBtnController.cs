using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtnController : MonoBehaviour {
	
	void OnMouseDown()
    {
        PlayerPrefs.SetInt("NextLevel", 2);
        SceneManager.LoadScene("Level-1");
    }
}
