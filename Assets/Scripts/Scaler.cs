using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] Transform scalerObj; 
    [SerializeField] float scalerMultiplier; 

    void Start()
    {
        // Get the  scale of the object to be scaled against
        // Update all axis via multiplier
        // Set the new scale of the object to be scaled
        Vector3 scale = scalerObj.localScale;        
        Vector3 updateScale = new Vector3(scale.x * scalerMultiplier, scale.y, scale.z * scalerMultiplier);        
        scalerObj.localScale = updateScale;
    }
}

