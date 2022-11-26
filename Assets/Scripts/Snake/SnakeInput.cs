using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class SnakeInput : MonoBehaviour
{
    private Camera _camera;

    private void Awake() => _camera = Camera.main;

    public Vector2 GetDirectionToClick(Vector2 headPosition)
    {
        Vector3 clickPosition = Input.mousePosition;

        clickPosition = _camera.ScreenToViewportPoint(clickPosition);
        clickPosition.y = 1f;
        clickPosition = _camera.ViewportToWorldPoint(clickPosition);

        Vector2 direction = new Vector2(clickPosition.x - headPosition.x, clickPosition.y - headPosition.y);

        return direction;
    }
}
