using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	public GameObject cubePrefab;
	public int rows = 10;
	public int cols = 10;
	public float spacing = 1.5f; // Adjust as needed

	void Start()
	{
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				Vector3 position = new Vector3(col * spacing, 0, row * spacing);
				GameObject newCube = Instantiate(cubePrefab, transform.position + position, Quaternion.identity);
				
				
			}
		}
	}
}
