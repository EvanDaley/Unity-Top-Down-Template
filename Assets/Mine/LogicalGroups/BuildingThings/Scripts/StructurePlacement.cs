using UnityEngine;

public class StructurePlacement : MonoBehaviour
{
    public GameObject actualStructurePrefab;
    public GameObject ghostStructurePrefab;
    private GameObject ghostStructure;

    void Update()
    {
        // Cast a ray from the camera to the ground plane
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Round the x and z coordinates to the nearest whole number
            float roundedX = Mathf.Round(hit.point.x);
            float roundedZ = Mathf.Round(hit.point.z);

            // Update the ghost's position to the rounded hit point on the ground
            ghostStructure.transform.position = new Vector3(roundedX, hit.point.y, roundedZ);
        }

        // Check for mouse click to place the structure
        if (Input.GetMouseButtonDown(0))
        {
            // float prefabHeight = actualStructurePrefab.GetComponent<Renderer>().bounds.size.y;

            // Calculate the offset
            // float offset = prefabHeight / 2;
            // Instantiate the actual structure prefab at the ghost's position plus the offset
            Instantiate(
                actualStructurePrefab, new Vector3(
                    ghostStructure.transform.position.x, 
                    ghostStructure.transform.position.y, 
                    ghostStructure.transform.position.z
                ), 
                ghostStructure.transform.rotation
            );
        }
    }

    void Start()
    {
        Debug.Log("start");
        // Create the initial ghost object
        ghostStructure = Instantiate(ghostStructurePrefab);
        // ghostStructure.SetActive(false); // Hide it initially
        Debug.Log(ghostStructure);
    }
}