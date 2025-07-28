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
                    StartCoroutine(InteractWithThumbnail(obj));
                }
            }
        }
    }

    IEnumerator InteractWithThumbnail(GameObject obj)
    {
        Vector3 targetPos = obj.transform.position + obj.transform.forward * 1.5f;
        Quaternion targetRot = Quaternion.LookRotation(obj.transform.position - Camera.main.transform.position);
        float t = 0f;
        float duration = 1f;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        // Show UI panel
        UIManager.Instance.ShowProjectInfo(obj);
    }
}

