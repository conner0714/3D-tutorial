using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageHazard : MonoBehaviour
{
    private int sectionSelect = 0;
    GameObject currentSelection;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpikedStage");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpikedStage()
    {
        sectionSelect = Random.Range(0,9);
        currentSelection = GameObject.Find("Ice_Fire_4 " + "(" + sectionSelect + ")");
        yield return new WaitForSeconds(5f);
        currentSelection.GetComponent<MeshCollider>().enabled = false;
        currentSelection.GetComponent<MeshRenderer>().material.color = new Color(256, 0, 0);
        yield return new WaitForSeconds(10f);
        currentSelection.GetComponent<MeshCollider>().enabled = true;
        currentSelection.GetComponent<MeshRenderer>().material.color = new Color(241, 188, 56);
    }
}
