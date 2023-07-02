using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag3d : MonoBehaviour
{
    Vector3 mousePositionOffset;
    Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
      this.mousePositionOffset = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z)
            - new Vector3 (GetMouseWorldPosition().x,0, GetMouseWorldPosition().z);
    }
    private void OnMouseDrag()
    {
        transform.position = new Vector3 (GetMouseWorldPosition().x- this.mousePositionOffset.x,0,
            GetMouseWorldPosition().z - this.mousePositionOffset.z+7);
    }
}
