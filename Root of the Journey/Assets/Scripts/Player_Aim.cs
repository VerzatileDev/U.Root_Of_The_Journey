using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition); // Expensive way of doing it.
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}