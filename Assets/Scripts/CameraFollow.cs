using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField] bool limitBounds = false;
    [SerializeField] float left = -5f;
    [SerializeField] float right = 5f;
    [SerializeField] float bottom = -5f;
    [SerializeField] float top = 5f;
    [SerializeField] float camera_x;
    [SerializeField] float camera_y;
    [SerializeField] float camera_z;
    private Vector3 lerpedPosition;

    private Camera m_camera;

    private void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
            lerpedPosition.x += camera_x;
            lerpedPosition.y += camera_y;
            lerpedPosition.z += camera_z;
        }
    }



    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = lerpedPosition;

            if (limitBounds)
            {
                Vector3 bottomLeft = m_camera.ScreenToWorldPoint(Vector3.zero);
                Vector3 topRight = m_camera.ScreenToWorldPoint(new Vector3(m_camera.pixelWidth, m_camera.pixelHeight));
                Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

                Vector3 boundPosition = transform.position;
                if (boundPosition.x > right - (screenSize.x / 2f))
                {
                    boundPosition.x = right - (screenSize.x / 2f);
                }
                if (boundPosition.x < left + (screenSize.x / 2f))
                {
                    boundPosition.x = left + (screenSize.x / 2f);
                }

                if (boundPosition.y > top - (screenSize.y / 2f))
                {
                    boundPosition.y = top - (screenSize.y / 2f);
                }
                if (boundPosition.y < bottom + (screenSize.y / 2f))
                {
                    boundPosition.y = bottom + (screenSize.y / 2f);
                }
                transform.position = boundPosition;
            }
        }
    }
}