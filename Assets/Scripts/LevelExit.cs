using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float flLevelLoadDelay = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
        
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(flLevelLoadDelay);
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int intNextSceneIndex = intCurrentSceneIndex + 1;
        if(intNextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            intNextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersists>().ResetScenePersist();
        SceneManager.LoadScene(intNextSceneIndex); 
        
    }

}
