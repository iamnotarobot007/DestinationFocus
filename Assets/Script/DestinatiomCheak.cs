using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationCheck : MonoBehaviour
{
    #region PUBLIC_VARS
    public PlayerController pc;
    public GameObject player;
    public LevelManager levelManager;
    #endregion

    #region UNITY_CALLBACKS
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
         
            pc.isPlaying = false;

            player.SetActive(false);

            Debug.Log("You Win!");
         
            levelManager.LoadNextLevel();

        }
    }
    #endregion
}


