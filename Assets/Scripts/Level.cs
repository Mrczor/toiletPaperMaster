using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform toiletPaperRoot;
    private List<Transform> toiletPapers;
    public List<Vector3> toiletPaperDefaultPositions;
    public Transform poopRoot;
    private List<Transform> poops;
    public List<Vector3> poopDefaultPositions;

    // Level cycle 
    void Start()
    {
        FindToiletPapers();
        FindPoops();
    }

    // Find the toilet papers in the level
    private void FindToiletPapers()
    {
        toiletPapers = new List<Transform>();
        toiletPaperDefaultPositions = new List<Vector3>();
        for(int i = 0; i < toiletPaperRoot.childCount; i++)
        {
            toiletPapers.Add(item: toiletPaperRoot.GetChild(i).transform);
            toiletPaperDefaultPositions.Add(toiletPaperRoot.GetChild(i).transform.position);
        }
    }
    // Find the poops in the level
    private void FindPoops()
    {
        poops = new List<Transform>();
        poopDefaultPositions = new List<Vector3>();
        for (int i = 0; i < poopRoot.childCount; i++)
        {
            poops.Add(item: poopRoot.GetChild(i).transform);
            poopDefaultPositions.Add(poopRoot.GetChild(i).transform.position);
        }
    }
    // Level resets
    public void ResetLevel()
    {
        for(int i = 0; i < toiletPapers.Count; i++)
        {
            toiletPapers[i].position = toiletPaperDefaultPositions[i];
            toiletPapers[i].SetParent(transform);
            toiletPapers[i].gameObject.SetActive(true);
        }
        for(int i = 0; i < poops.Count; i++)
        {
            poops[i].position = poopDefaultPositions[i];
            poops[i].SetParent(transform);
            poops[i].gameObject.SetActive(true);
        }
    }
}
