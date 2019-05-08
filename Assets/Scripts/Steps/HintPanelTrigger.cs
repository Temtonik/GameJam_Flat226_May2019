using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanelTrigger : MonoBehaviour
{
    public GameObject hintPanelPrefab,HintPanelTarget;
    public float speed;

    private GameObject hintPanel;
    private bool moveToDestination = true;
    //private Vector3 characterPosition;

    private void Update()
    {
        if (hintPanel != null && moveToDestination)
        {
            hintPanel.transform.position = Vector3.MoveTowards(hintPanel.transform.position, HintPanelTarget.transform.position, speed * Time.deltaTime);
            hintPanel.transform.rotation = Quaternion.RotateTowards(hintPanel.transform.rotation, HintPanelTarget.transform.rotation, speed * Time.deltaTime * 6f);
            if (hintPanel.transform.position == HintPanelTarget.transform.position)
            {
                moveToDestination = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 randomPosition = Camera.main.transform.GetChild(1).position;

            hintPanel = Instantiate(hintPanelPrefab, randomPosition, Quaternion.LookRotation(new Vector3(0, 0, HintPanelTarget.transform.position.z)));

            float AngleRad = Mathf.Atan2(HintPanelTarget.transform.position.y - hintPanel.transform.position.y, HintPanelTarget.transform.position.x - hintPanel.transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            hintPanel.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
