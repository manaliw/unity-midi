using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class rotate : MonoBehaviour
{
    public GameObject originalObject;

    public Light lightA, lightB;

    private List<GameObject> clonedObjects = new List<GameObject>();


    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -5; x <= 5; x++) {
            for (int z = -5; z <= 5; z++) 
            {
                GameObject clonedObject = Instantiate(
                    originalObject, 
                    new Vector3(x, 0, z), 
                    Quaternion.identity
                );

                clonedObject.transform.parent = this.transform;
                clonedObject.SetActive(true);

                clonedObjects.Add(clonedObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        float xRotation = MidiMaster.GetKnob(0x0A, 0);
        float yRotation = MidiMaster.GetKnob(0x4A, 0);
        float zRotation = MidiMaster.GetKnob(0x47, 0);

        foreach (GameObject clonedObject in clonedObjects)
        {
            transform.Rotate(xRotation, yRotation, zRotation);
        }

        bool randomize = MidiMaster.GetKeyDown(0x2C);

        if (randomize) {
            float randomHueA = Random.Range(0f, 1f);
            float randomHueB = Random.Range(0f, 1f);
            float randomSatA = Random.Range(0f, 1f);
            float randomSatB = Random.Range(0f, 1f);

            lightA.color = Color.HSVToRGB(randomHueA, randomSatA, 1f);
            lightB.color = Color.HSVToRGB(randomHueB, randomSatB, 1f);
        }
           
        
    }
}

