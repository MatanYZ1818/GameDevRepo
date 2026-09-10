using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    public GameObject Player;
    public GameObject AllCoins;
    public static int CoinCount = 0;
    public Text coinsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //only player can collect coins
        //if(other.gameObject == Player.gameObject)
        {
            Debug.Log("Coin collected");
            CoinCount++;
            coinsText.text = "Gold: " + CoinCount;
            gameObject.SetActive(false);
            AudioSource sound = AllCoins.GetComponent<AudioSource>();
            sound.Play();
        }
    }
}
