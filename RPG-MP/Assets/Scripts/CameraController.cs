using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private readonly Vector2 minBounds = new Vector2(-15f, -15f); // bottom-left world corner
    private readonly Vector2 maxBounds = new Vector2(15f, 15f);   // top-right world corner

    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        // does the player exist?
        if (PlayerController.me != null && !PlayerController.me.dead)
        {
            Vector3 targetPos = PlayerController.me.transform.position;
            targetPos.z = -10;

            // clamp to map bounds
            float clampedX = Mathf.Clamp(targetPos.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(targetPos.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

            transform.position = new Vector3(clampedX, clampedY, targetPos.z);
        }
    }
}
