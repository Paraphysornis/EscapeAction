using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject playerObject;

    void Update()
    {
        this.transform.position = new Vector3(playerObject.transform.position.x, 3.5f, -10);
    }
}
