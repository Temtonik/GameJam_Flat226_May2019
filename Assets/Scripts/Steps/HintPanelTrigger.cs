﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanelTrigger : MonoBehaviour
{
    public GameObject hintPanelPrefab, hintPanelSpawner,HintPanelTarget;
    public float speed;

    private GameObject hintPanel;
    private Vector3 characterPosition;

    private void Update()
    {
        hintPanel.transform.position = Vector3.MoveTowards(hintPanel.transform.position, characterPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hintPanel = Instantiate(hintPanelPrefab, hintPanelSpawner.transform.position, Quaternion.identity);
            characterPosition = HintPanelTarget.transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}