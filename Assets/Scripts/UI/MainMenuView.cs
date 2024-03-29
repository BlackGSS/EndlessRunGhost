using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToCosmetic()
    {
        SceneManager.LoadScene("Store");
    }
}
