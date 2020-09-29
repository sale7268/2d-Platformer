﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        Debug.Log("File: " + filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log("Line: " + line);
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    SpawnPrefab(letter, new Vector3(column+0.6f, row+14.5f, 0));
                    column++;
                }
                --row;
            }
            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn = null;
        Debug.Log("Position spawn initial " + positionToSpawn);
        switch (spot)
        {
            case 'b': ToSpawn = Brick;  break;
            case '?': ToSpawn = QuestionBox;  break;
            case 'x': ToSpawn = Stone;  break;
            case 's': ToSpawn = Rock;  break;
            default:  return;
        }


        ToSpawn = GameObject.Instantiate(ToSpawn, positionToSpawn, Quaternion.identity);
        ToSpawn.transform.position = positionToSpawn;
        Debug.Log("Position spawn final: " + positionToSpawn);
        Debug.Log("ToSpawn: " + ToSpawn);
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
