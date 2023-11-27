using UnityEngine;

public class TriangleTrigger : MonoBehaviour
{
    #region PRIVATE_VARS
    [SerializeField] SpriteRenderer sp;
    #endregion

    #region UNITY_CALLBACKS
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            Collider2D[] childColliders = GetComponentsInChildren<Collider2D>();
            foreach (Collider2D collider in childColliders)
            {
                collider.isTrigger = false;
            } 
            Color currentColor = sp.color;
            currentColor.a = 1f;
            sp.color = currentColor;
        }
    }
    #endregion
}


