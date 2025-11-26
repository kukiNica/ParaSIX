using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // <- necesario para UI

public class Doctor : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private List<Vector2> waypoints = new List<Vector2>();
    private Vector2 newWaypoint;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Ignorar clic si está sobre UI
            if (IsPointerOverUI())
                return;

            // CHEQUEAR SI CLICASTE UN OBJETO INTERACTIVO (NPC, etc)
            RaycastHit2D hit = Physics2D.Raycast(
                cam.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero
            );

            if (hit.collider != null)
                return;

            // Mover jugador al clic en el mundo
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3 viewPos = cam.WorldToViewportPoint(mousePos);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            {
                newWaypoint = mousePos;
                waypoints.Add(newWaypoint);
            }
        }

        Move();
    }

    private void Move()
    {
        if (waypoints.Count == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, newWaypoint, speed * Time.deltaTime);

        if ((Vector2)transform.position == waypoints[0])
            waypoints.RemoveAt(0);

        ClampToCamera();
    }

    private void ClampToCamera()
    {
        Vector3 pos = transform.position;

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float minX = cam.transform.position.x - camWidth / 2f;
        float maxX = cam.transform.position.x + camWidth / 2f;
        float minY = cam.transform.position.y - camHeight / 2f;
        float maxY = cam.transform.position.y + camHeight / 2f;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    // ------------------------------
    // FUNCION PARA CHEQUEAR UI
    private bool IsPointerOverUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<UnityEngine.UI.Button>() != null ||
                result.gameObject.GetComponent<CanvasRenderer>() != null)
            {
                return true; // está sobre un botón o panel
            }
        }

        return false;
    }
}
