using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    public void NextScene(string scene_name)
        {
            SceneManager.LoadScene(1);
        }

    }

