using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        transform.position = target.transform.position + new Vector3(0, 1, -8);
    }
}
