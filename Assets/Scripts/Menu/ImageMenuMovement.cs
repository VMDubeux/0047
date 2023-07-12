using UnityEngine;

public class ImageMenuMovement : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }
}
