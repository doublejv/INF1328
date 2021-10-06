using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBoundaries : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        if (viewPos.y < screenBounds.y  * -1 || viewPos.y > screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}
