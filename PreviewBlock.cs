using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewBlock : MonoBehaviour
{
    public GameObject[] previewBlocks;
    public GameObject temp = null;

    public void ShowBlock(int i) //spawn preview block and delete past preview
    {
        if (temp == null)
        {
            temp = Instantiate(previewBlocks[i], transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(temp);
            temp = Instantiate(previewBlocks[i], transform.position, Quaternion.identity);
        }
    }

}
