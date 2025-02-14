using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    private float spacing = 1f;

    void Start()
    {
        for (int r = 1; r < 6; r++)
        {
            for (int s = -9; s <= 9; s++)
            {
                Spawn(s, r);
            }
        }
    }

    void Spawn(float x, float y)
    {
        var spawnObject = GameObject.Find("BaseBlock");
        spawnObject.tag = "Block";
        Vector3 position = new Vector3(x * spacing, 19 - y, 0);
        Instantiate(spawnObject, position, Quaternion.identity);
    }
}
