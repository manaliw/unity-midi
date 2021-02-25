using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class rotateobject : MonoBehaviour
{
    public GameObject originalObject;

    public Light lightA, lightB;

    // Start is called before the first frame update
    void Start()
    {

        originalObject.transform.parent = this.transform;
        originalObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        //float speed = MidiMaster.GetKnob(0x47, 0) / 10;
        float xRotation = MidiMaster.GetKnob(0x0A, 0);
        float yRotation = MidiMaster.GetKnob(0x4A, 0);
        float zRotation = MidiMaster.GetKnob(0x47, 0);

        transform.Rotate(xRotation, yRotation, zRotation);  

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
