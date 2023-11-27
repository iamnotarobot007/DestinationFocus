using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    #region PRIVATE_VARS
    [SerializeField] LevelManager levelManager;
    [SerializeField] Button[] levelButtons;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i;

            levelButtons[i].onClick.AddListener(() => SelectLevel(levelIndex));
        }
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    void SelectLevel(int levelIndex)
    {
        levelManager.LoadLevel(levelIndex);
    }
    #endregion
}

