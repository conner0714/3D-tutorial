using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageHazard : MonoBehaviour
{
    private int sectionSelect = 0;
    private int spikeSelect = 0;
    GameObject disappearCurrentSelection;
    GameObject spikeCurrentSelection;
    private bool stageReady = true;
    private bool spikeReady = true;
    private string currentSelectString = "";
    PlayerHP playerHP;
    private GameObject playerHealthCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthCanvas = GameObject.Find("Player Stats Overview");
        playerHP = playerHealthCanvas.GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stageReady)
        {
            StartCoroutine("DisappearingStage");
        }

        if (spikeReady)
        {
            StartCoroutine("SpikedStage");
        }
    }

    IEnumerator DisappearingStage()
    {
        stageReady = false;
        spikeReady = false;
        sectionSelect = Random.Range(0,9);
        disappearCurrentSelection = GameObject.Find("Ice_Fire_4 " + "(" + sectionSelect + ")");
        disappearCurrentSelection.GetComponent<MeshRenderer>().material.color = new Color(231/256f, 103/256f, 103/256f);
        spikeSelect = Random.Range(0,9);
        currentSelectString = "Ice_Fire_4 " + "(" + spikeSelect + ")";
        spikeCurrentSelection = GameObject.Find(currentSelectString);
        spikeCurrentSelection.GetComponent<MeshRenderer>().material.color = new Color(0f, 103/256f, 0f);
        yield return new WaitForSeconds(5f);
        disappearCurrentSelection.GetComponent<MeshRenderer>().material.color = new Color(1f, 0, 0);
        disappearCurrentSelection.GetComponent<MeshCollider>().enabled = false;
        spikeCurrentSelection.GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0);
        playerHP.PlayerDamaged(20f);
        yield return new WaitForSeconds(10f);
        disappearCurrentSelection.GetComponent<MeshCollider>().enabled = true;
        disappearCurrentSelection.GetComponent<MeshRenderer>().material.color = new Color(241/256f, 188/256f, 56/256f);
        spikeCurrentSelection.GetComponent<MeshRenderer>().material.color = new Color(241/256f, 188/256f, 56/256f);
        stageReady = true;
        spikeReady = true;
    }
    
}
