using System.Collections;
using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    public GameObject target;
    private Camera mainCam;
    public GameObject referencePosition;
    public Player_Control player;
    public float teleportDistance = 1.1f;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }
    void Update()
    {
        playerFlareLookAround();
        playerFollow();
        Debug.Log(referencePosition.transform.position);
        
    }

    void playerFlareLookAround()
    {
        Vector3 mouse = Input.mousePosition;

        //Debug.Log(Input.mousePosition);
        Vector3 screenPoint = mainCam.WorldToScreenPoint(transform.localPosition); // Expensive way of doing it.


        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(1))
        {
            if (referencePosition.transform.rotation.z < 180f && referencePosition.transform.rotation.z > 0f)
            {
                //Vector3 mousePos = Input.mousePosition;
                player.gameObject.SetActive(false);
                mouse.z = target.transform.position.z - mainCam.transform.position.z; // setting 0
                Vector3 getWorldPoints = mainCam.ScreenToWorldPoint(mouse);
                target.transform.position = getWorldPoints / teleportDistance;
                player.gameObject.SetActive(true);
            }
            
        }
        Debug.DrawLine(target.transform.position, referencePosition.transform.position, Color.blue);
    }

    void playerFollow()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .1f); // Follow User
    }

}