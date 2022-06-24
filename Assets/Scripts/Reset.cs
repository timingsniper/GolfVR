using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameCore_Data;

public class Reset : MonoBehaviour
{
    public void ResetTheGame()
    {
        finished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
