using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButtonController : MonoBehaviour {
    [SerializeField]
    private int targetSceneIndex = 1;

    public void onClick() {
        SceneManager.LoadScene(targetSceneIndex);
    }
}
