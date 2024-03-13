using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Continue() {
        SceneManager.LoadScene(7);
    }
    public void ExitGame() {
        SceneManager.LoadScene(2);
    }
}
