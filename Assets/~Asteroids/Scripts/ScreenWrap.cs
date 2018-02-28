using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenWrap : MonoBehaviour

    {
        private SpriteRenderer spriteRenderer;
        private Bounds camBounds;
        private float camWidth;
        private float camHeight;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void UpdateCameraBounds()
        {
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
        }

        // Update is called once per frame
        void LateUpdate()
        {
            UpdateCameraBounds();
            Vector3 pos = transform.position;
            Vector3 size = spriteRenderer.bounds.size;
            float halfWidth = size.x / 2f;
            float halfHeight = size.y / 2f;
            if (pos.x + halfWidth < camBounds.min.x)
            {
                pos.x = camBounds.max.x + halfWidth;
            }
            if (pos.x - halfWidth > camBounds.max.x)
            {
                pos.x = camBounds.min.x - halfWidth;
            }
            if (pos.y + halfHeight < camBounds.min.y)
            {
                pos.y = camBounds.max.y + halfHeight;
            }
            if (pos.y - halfHeight > camBounds.max.y)
            {
                pos.y = camBounds.min.y - halfHeight;
            }

            transform.position = pos;
        }
    }
}
