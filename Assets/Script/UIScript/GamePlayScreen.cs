using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    public PlayerController pc;
    #endregion

    #region PUBLIC_FUNCTIONS
    public void OnPlayBtnClick()
    {
        pc.isPlaying = true;
    }
    #endregion
}
