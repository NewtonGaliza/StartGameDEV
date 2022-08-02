using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>(); //puxando o component Player, que esta presente no PlayerItems
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItems.TotalWater / playerItems.BucketLimit;
        woodUIBar.fillAmount = playerItems.TotalWood / playerItems.WoodLimit;
        carrotUIBar .fillAmount = playerItems.TotalCarrots / playerItems.CarrotsLimit;
        fishUIBar.fillAmount = playerItems.TotalFishes / playerItems.FishesLimit;

        //toolsUI[player.handlingObj].color = selectColor; //indice da lista é o item segurado pelo personagem

        ToolSelected();
    }

void ToolSelected()
{
   for(int i = 0; i < toolsUI.Count; i++)
    {
        if(i == player.handlingObj)
        {
            toolsUI[i].color = selectColor;
        }
        else
        {
            toolsUI[i].color = alphaColor;
        }
    }
}



}


