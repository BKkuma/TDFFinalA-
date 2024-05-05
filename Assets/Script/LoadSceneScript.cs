using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public void Loadscene(string scenenname)
    {
        SceneManager.LoadScene(scenenname);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
