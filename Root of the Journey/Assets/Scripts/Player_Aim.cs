using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    public GameObject target;
    private Camera mainCam;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Debug.Log(Input.mousePosition);
        Vector3 screenPoint = mainCam.WorldToScreenPoint(transform.localPosition); // Expensive way of doing it.


        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .1f); // Follow User
    }
}