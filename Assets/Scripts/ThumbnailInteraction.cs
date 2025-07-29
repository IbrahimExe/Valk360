using UnityEngine;

public class ThumbnailInteraction : MonoBehaviour
{
    public float maxDistance = 3f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, maxDistance))
            {
                if (hit.collider.CompareTag("Thumbnail"))
                {
                    var obj = hit.collider.gameObject;
                    // Start centering process
                }
            }
        }
    }

}

