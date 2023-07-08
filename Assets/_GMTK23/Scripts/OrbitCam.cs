using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Willow.Library;

public class OrbitCam : MonoBehaviour
{
    public float distance;

    public Vector3 top;
    public Vector3 bottom;

    public float rotation;
    public float elevation;

    public Vector2 sensetivity;
    
    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse == null) return;

        if (mouse.leftButton.isPressed)
        {
            Vector2 delta = mouse.delta.ReadValue();

            rotation += delta.x * sensetivity.x;
            elevation -= delta.y * sensetivity.y;
            elevation = elevation.Clamp01();
        }

        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        Vector3 center = Vector3.Lerp(bottom, top, elevation);
        transform.position = center - transform.forward * distance;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(top, bottom);
    }
}
