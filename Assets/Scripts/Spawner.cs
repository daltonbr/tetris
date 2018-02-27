using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] tetrominos;

	void Start ()
    {
	    SpawnNext();	
	}

    public void SpawnNext()
    {
        // pseudo-random
        int i = Random.Range(0, tetrominos.Length);

        Instantiate(tetrominos[i], transform.position, Quaternion.identity);
    }
    
}
