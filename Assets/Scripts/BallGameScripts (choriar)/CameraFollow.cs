using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{

    public float smoothSpeed;
    public Vector3 cameraOffset;
    public List<Transform> targets;

    public float minZoom = 65f;
    public float maxZoom = 30f;
    public float zoomLimiter = 40f;
    public new Camera camera;

    private void Start()
    {
        AddObjectsToList();
        camera = GetComponent<Camera>();
    }
    public void AddObjectsToList()
    {
        GameObject target = GameObject.FindWithTag("CameraTarget");
        Transform targetTransform = target.transform;
        targets.Add(targetTransform);
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }
    void Move()
    {
        Vector3 desiredPosition = GetCenterPoint() + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp( minZoom, maxZoom, GetGreatestDistance() / zoomLimiter);
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newZoom, smoothSpeed * Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    
    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i< targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
