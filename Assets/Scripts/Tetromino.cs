using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float _fall = 0f;
    public float FallSpeed = 1f;
    public bool IsActive = false;
    [SerializeField] private bool _allowRotation = true;
    [SerializeField] private bool _limitRotation = false;

    void Start ()
    {
		Initialize();
	}

    public void Initialize()
    {
        IsActive = true;
        StartCoroutine(DescentMovement());
    }

    IEnumerator DescentMovement()
    {
        while (true)
        {
            while (IsActive)
            {
                transform.position += Vector3.down;
                yield return new WaitForSeconds(FallSpeed);
            }
            yield return new WaitForSeconds(3);
        }
    }

	void Update ()
    {
		CheckUserInput();
	}

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
        }
    }

    bool CheckIsValidPosition()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = Game.Round(mino.position);
            if (Game.CheckIsInsideGrid(pos) == false)
            {
                return false;
            }            
        }
        return true;
    }
}
