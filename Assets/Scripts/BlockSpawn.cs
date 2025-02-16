using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    private float spacing = 1f;
    private GameObject SpawnObject;
    private GameObject CoinObject;

    private void Start()
    {
        SpawnObject = GameObject.Find("BaseBlock");
        CoinObject = GameObject.Find("BaseCoin");
    }

    void SpawnBlock(float x, float y)
    {
        SpawnObject = GameObject.Find("BaseBlock");
        Vector3 position = new Vector3(x * spacing, 19 - y, 0);
        var newBlock = Instantiate(SpawnObject, position, Quaternion.identity);
        newBlock.tag = "Block";
    }

    void SpawnCoin(float x, float y)
    {
        SpawnObject = GameObject.Find("BaseCoin");
        Vector3 position = new Vector3(x * spacing, 19 - y, 0);
        var newBlock = Instantiate(SpawnObject, position, Quaternion.identity);
        newBlock.tag = "Block";
    }

    public void StartSpawn()
    {
        int counter = 0;
        for (int r = 1; r < 6; r++)
        {
            for (int s = -9; s <= 9; s++)
            {
                if (IsPrime(counter))
                    SpawnCoin(s, r);
                else
                    SpawnBlock(s, r);

                counter++;
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

    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
