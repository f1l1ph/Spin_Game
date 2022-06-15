using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] blocks;
    [SerializeField] private GameObject[] blocksGMO;

    [SerializeField] private Sprite[] islands;

    [SerializeField] private float blockRotationSpeed;
    //scaling stuff
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float beginningScale = 3;
    [SerializeField] private bool randomSpinning = false;

    int randomSpinner; 


    void Start()
    {
        randomSpinner = Random.Range(0, 2);
        if (randomSpinner == 0 && randomSpinning)
        {
            blockRotationSpeed *= -1;
        }

        transform.localScale = new Vector3(beginningScale, beginningScale, beginningScale);

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].sprite = islands[Random.Range(0, islands.Length)];
        }


        for (int i = 1; i <= Random.Range(1,5); i++)
        {
            GameObject randomBlock = blocksGMO[Random.Range(0, blocks.Length-1)];
            Destroy(randomBlock);
        }
    }

    void FixedUpdate()
    {
        float scaleNum = 0;
        scaleNum = transform.localScale.x - (Time.deltaTime * scaleSpeed);

        if(transform.localScale.y <= .1f)
        {
            Destroy(gameObject);
            StaticClass.score++;
        }

        if (StaticClass.pausedGame == false)
        {
            transform.localScale = new Vector3(scaleNum, scaleNum, scaleNum);

            transform.Rotate(new Vector3(0, 0, blockRotationSpeed));
        }
        else if (StaticClass.pausedGame == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }
}
