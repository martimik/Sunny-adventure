using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtnController : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
