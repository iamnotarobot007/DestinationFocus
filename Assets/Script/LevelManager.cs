using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public GameObject[] levels; 
    public GameObject player;
    public Vector3[] playerStartPositions;
    #endregion

    #region PRIVATE_VARS
    private int currentLevelIndex = 0;
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
        player.transform.position = playerStartPositions[currentLevelIndex];
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void LoadLevel(int levelIndex)
    {
      
        levels[currentLevelIndex].SetActive(false);

        currentLevelIndex = levelIndex;
     
        levels[currentLevelIndex].SetActive(true);

        player.transform.position = playerStartPositions[currentLevelIndex];
      
    }

    public void LoadNextLevel()
    {
      
        levels[currentLevelIndex].SetActive(false);

        currentLevelIndex++;

        if (currentLevelIndex < levels.Length)
        {
            levels[currentLevelIndex].SetActive(true);

            player.SetActive(true);

            player.transform.position = playerStartPositions[currentLevelIndex];
        }
        else
        {
           
        }
    }
    #endregion
}

