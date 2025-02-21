using UnityEngine;

public class bordersOfWorld : MonoBehaviour
{
    private float minX = -2000f, maxX = 2000f;
    private float minZ = -2000f, maxZ = 2000f;
    private float minY = -2000f, maxY = 2000f;
    void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        gameObject.transform.position = pos;
    }
}
