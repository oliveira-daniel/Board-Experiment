using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector2 velocity;
    public float smoothTimeX, smoothTimeY;
    public Vector2 maxCamPos, minCamPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX),
                posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z
            );
        }
    }
}
