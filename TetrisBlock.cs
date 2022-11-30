using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{

    public Vector3 rotationPoint;
    private float previousTime;
    public static float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    public static float speed = 0.8f;
    

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<PauseMenu>().pause)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))//moving left
            {
                transform.position += new Vector3(-1, 0, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))//moving right
            {
                transform.position += new Vector3(1, 0, 0);
                if(!ValidMove())
                    transform.position -= new Vector3(1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))//rotate
            {
                FindObjectOfType<AudioAssistance>().RotateSound();
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                if (!ValidMove())
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }


            if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.DownArrow) ? fallTime / 10 : speed))//fall and moving down
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    AddToGrid();
                    CheckForLines();
                    this.enabled = false;
                    if (GameOver())//display game over menu
                    {
                        print("GAME OVER");
                        FindObjectOfType<GameOverMenu>().gameOverMenu.SetActive(true);
                        FindObjectOfType<AudioAssistance>().GameOverSound();
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        int currentBlock = FindObjectOfType<SpawnerBlocks>().GenBlocks();
                        FindObjectOfType<SpawnerBlocks>().NewBlocks(currentBlock);

                    }
                }
                previousTime = Time.time;
            }
        }
        print(speed);
        print(fallTime);
    }


    void Difficulty()//increasing difficulty every 500 points
    {
        if (FindObjectOfType<ScoreManager>().score % 500 == 0 && FindObjectOfType<ScoreManager>().score > 0)
        {
            speed /= 2f;
            FindObjectOfType<AudioAssistance>().SpeedUpSound();
            ScoreManager.instance.SpeedUp();
        }
    }


    bool GameOver()
    {
        for (int i = 0; i < width; i++)
        {
            if (grid[i, height - 1] != null)
            {
                return true;
            }
        }
        return false;
    }


    void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                Difficulty();
            }
        }
    }


    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }


    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        ScoreManager.instance.AddScore();

        FindObjectOfType<AudioAssistance>().LineCollectSound();
    }


    void RowDown(int i)
    {
        for (int k = i; k < height; k++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j,k] != null)
                {
                    grid[j, k - 1] = grid[j, k];
                    grid[j, k] = null;
                    grid[j, k - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }


    void AddToGrid()//creating a grid of blocks
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            int roundedX = Mathf.RoundToInt(position.x);
            int roundedY = Mathf.RoundToInt(position.y);

            grid[roundedX, roundedY] = children;
        }
    }


    bool ValidMove()//restriction of movement
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            int roundedX = Mathf.RoundToInt(position.x);
            int roundedY = Mathf.RoundToInt(position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}