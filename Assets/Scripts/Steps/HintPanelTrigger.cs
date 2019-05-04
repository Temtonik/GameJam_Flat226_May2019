using System.Collections;
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
        if (hintPanel != null)
        {
            if (hintPanel.transform.position != characterPosition)
            {
                hintPanel.transform.position = Vector3.MoveTowards(hintPanel.transform.position, characterPosition, speed * Time.deltaTime);
                hintPanel.transform.rotation = Quaternion.RotateTowards(hintPanel.transform.rotation, HintPanelTarget.transform.rotation, speed * Time.deltaTime * 6f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            characterPosition = HintPanelTarget.transform.position;
            Vector2 randomPosition = new Vector2(Mathf.PerlinNoise(0,1) * 10, hintPanelSpawner.transform.position.y);

            hintPanel = Instantiate(hintPanelPrefab, randomPosition, Quaternion.LookRotation(new Vector3(0, 0, HintPanelTarget.transform.position.z)));

            float AngleRad = Mathf.Atan2(characterPosition.y - hintPanel.transform.position.y, characterPosition.x - hintPanel.transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            hintPanel.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
