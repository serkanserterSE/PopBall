using System.Threading;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    private float spacing = 1f;

    public void StartSpawn()
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
        Vector3 position = new Vector3(x * spacing, 19 - y, 0);
        var newBlock = Instantiate(spawnObject, position, Quaternion.identity);
        newBlock.tag = "Block";
    }

    public void ClearAllBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var block in blocks)
        {
            Destroy(block);
        }
    }
}
