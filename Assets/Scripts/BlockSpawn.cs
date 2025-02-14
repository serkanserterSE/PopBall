using System.Threading;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    private float spacing = 1f;
    private GameObject SpawnObject;

    private void Start()
    {
        SpawnObject = GameObject.Find("BaseBlock");
    }

    void Spawn(float x, float y)
    {
        SpawnObject = GameObject.Find("BaseBlock");
        Vector3 position = new Vector3(x * spacing, 19 - y, 0);
        var newBlock = Instantiate(SpawnObject, position, Quaternion.identity);
        newBlock.tag = "Block";
    }

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

    public void ClearAllBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var block in blocks)
        {
            Destroy(block);
        }
    }
}
