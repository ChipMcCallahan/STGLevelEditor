using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMover : MonoBehaviour
{
    public RectTransform cameraBox;

    // Update is called once per frame
    void Update()
    {
        var ox = (cameraBox.position.x - cameraBox.rect.width / 2);
        var oy = (cameraBox.position.y - cameraBox.rect.height / 2);
        Vector3 offset = new Vector3(-ox / 32f, oy / 32f, 1);
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
        transform.position += offset;
        var v = transform.position;
        transform.position = new Vector3(Mathf.Floor(v.x) + 0.5f, Mathf.Floor(v.y) + 0.5f, v.z);
    }
}
