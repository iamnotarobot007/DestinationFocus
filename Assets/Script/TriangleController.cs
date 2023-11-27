using UnityEngine;

public class TriangleController : MonoBehaviour
{
    public float currentAngle ;    

    #region PRIVATE_FUNCTIONS
    void OnMouseDown()
    {
        RotateTriangle();
    }

    void RotateTriangle()
    {        
        transform.Rotate(0, 0, 90);
        currentAngle = transform.localEulerAngles.z;
    }
    #endregion
  
    
}



