using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;

    [SerializeField] private int percentage; //porcentagem pra pescar um peixe por tentativa

    [SerializeField] private GameObject fishPrefab;

    private PlayerAnim playerAnim;
    private PlayerItems player;

    // Start is called before the first frame update
    void Start()
    {
         player = FindObjectOfType<PlayerItems>();
         playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue <= percentage)
        {
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-3, -1), Random.Range(0, 2), 0f), Quaternion.identity);
        }
        else
        {
            Debug.Log("VENTO");
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
