//Накладывается на оба джойстика
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    
{
    [SerializeField] GameObject handle;
    [SerializeField] Vector3 positionHandler;
    public Vector3 direction;
    public bool isMoving;

    private void Start()
    {
        positionHandler = handle.transform.position;
    }


    public void OnDrag(PointerEventData eventData)
    {
        
        Vector3 tempPos = eventData.position;
        direction = positionHandler - tempPos;
        if (direction.x > 100)
            direction.x = 100;
        if (direction.x < -100)
            direction.x = -100;
        if (direction.y > 100)
            direction.y = 100;
        if (direction.y < -100)
            direction.y = -100;
        handle.transform.position = (positionHandler - direction);
        direction = new Vector3(-direction.x / 100, -direction.y / 100, -direction.z / 100);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        handle.transform.position = positionHandler;
        direction = Vector3.zero;
        isMoving = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isMoving = true;
    }
}
