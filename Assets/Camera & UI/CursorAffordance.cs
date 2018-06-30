using UnityEngine;
[RequireComponent(typeof(CameraRaycaster))]
class CursorAffordance : MonoBehaviour {

  [SerializeField] Texture2D  walkCursor = null;
  [SerializeField] Texture2D  attackCursor = null;
  [SerializeField] Texture2D  errorCursor = null;

  private Vector2 cursorHotspot = new Vector2(0, 0);
  private Texture2D m_prevCursor;
  private CameraRaycaster cameraRaycaster;
  void Start() {
    cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
    cameraRaycaster.notifyLayerChangeObservers += OnHoverLayerChange; // TODO: consider de-registering on leaving scene
  }

  void OnHoverLayerChange(int newLayer) {
    Debug.Log(newLayer);
    Texture2D nextCursor;
    switch ((Layer)newLayer) {
      case Layer.Walkable:
        nextCursor = walkCursor;
        break;
      case Layer.Enemy:
        nextCursor = attackCursor;
        break;
      case Layer.RaycastEndStop:
        nextCursor = errorCursor;
        break;
      default:
        nextCursor = errorCursor;
        break;
    }

    if (m_prevCursor != nextCursor)
      Cursor.SetCursor(nextCursor, cursorHotspot, CursorMode.Auto);
  }
}