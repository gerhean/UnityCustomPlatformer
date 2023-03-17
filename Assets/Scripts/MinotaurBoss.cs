using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinotaurBoss : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bossDialogueText;
    [SerializeField] GameObject bossSpeechBubble;
    [SerializeField] GameObject dioSprite;

    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] GameObject playerSpeechBubble;
    public float movementSpeed = 1f;
    public GameObject playerRef;
    private bool playerNear = false;
    private bool playerFar = true;

    private void Awake()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator disappearBubble(int secs)
    {
        yield return new WaitForSeconds(secs);
        bossSpeechBubble.SetActive(false);
    }

    IEnumerator appearPlayerBubble(float secs_appear, float secs_disappear, string text)
    {
        yield return new WaitForSeconds(secs_appear);
        playerSpeechBubble.SetActive(true);
        playerDialogueText.text = text;
        yield return new WaitForSeconds(secs_disappear);
        playerSpeechBubble.SetActive(false);
    }

    private void Update()
    {
        // Chase if in range
        if (Vector2.Distance(gameObject.transform.position, playerRef.transform.position) <= 2f) {
            StartCoroutine(appearPlayerBubble(0.5f, 2.0f, "ORA ORA ORA ORA!"));
            bossSpeechBubble.SetActive(true);
            bossDialogueText.text = "MUDA MUDA MUDA MUDA!";
        }
        if (Vector2.Distance(gameObject.transform.position, playerRef.transform.position) <= 10f)
        {
            if (playerFar) {
                playerFar = false;
                playerNear = true;
                dioSprite.SetActive(true);
                bossSpeechBubble.SetActive(true);
                bossDialogueText.text = "Oh? Are you approaching me?";
                StartCoroutine(disappearBubble(2));
                StartCoroutine(appearPlayerBubble(0.2f, 2.0f, "I can't beat the shit out of you without getting closer."));
            }
            gameObject.transform.position = Vector2.MoveTowards(
                gameObject.transform.position, playerRef.transform.position, movementSpeed * Time.deltaTime
            );
        }
        else {
            if (playerNear) {
                playerFar = true;
                playerNear = false;
                bossSpeechBubble.SetActive(true);
                bossDialogueText.text = "Where's your MOTIVATION?";
                StartCoroutine(disappearBubble(2));
            }
        }
        
        // else Idle
    }

}
