using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlocks : MonoBehaviour
{
    public GameObject[] Blocks;
    Queue<int> queueBlock = new Queue<int>();
    public static int currentBlock;
    public static int nextBlock;


    // Start is called before the first frame update
    void Start()
    {

        queueBlock.Enqueue(Random.Range(0, Blocks.Length)); //queue filling
        queueBlock.Enqueue(Random.Range(0, Blocks.Length));

        GenBlocks(); //spawn first preview tetromino

        NewBlocks(Random.Range(0, Blocks.Length));//spawn first tetromino

    }

    public void NewBlocks(int i) //spawn tetromino
    {
//        print(Blocks.Length);
        Instantiate(Blocks[i], transform.position, Quaternion.identity);

    }

    public int GenBlocks() //create queue
    {
        currentBlock = queueBlock.Dequeue();
        nextBlock = Random.Range(0, Blocks.Length);
        queueBlock.Enqueue(nextBlock);

//        print(queueBlock.Peek());

        FindObjectOfType<PreviewBlock>().ShowBlock(queueBlock.Peek());

        return currentBlock;
    }
}
