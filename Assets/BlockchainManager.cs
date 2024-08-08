using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms;

public class BlockchainManager : MonoBehaviour
{
    public string Address { get; private set; }

    public Button nftBtn;
    public Text nftBtnTxt;
    public Button playBtn;
    public Text playBtnText;
    public Button speedx2Btn;
    public Text speedx2BtnText;

    private void Start()
    {
        nftBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(false);
        speedx2Btn.gameObject.SetActive(false);
    }

    public async void CheckTokenGatePass()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        //For Testing
        Address = "0x4C6F5f4e21840f1e103fF8791AC70b4Ff1AD59f9";
        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0x7aC00cc9868Ff562D3285918632563C41e5807f8",
            "[{\"type\":\"event\",\"name\":\"gameKeyGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"tokenGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"int256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"int256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getToken\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"int256\",\"name\":\"\",\"internalType\":\"int256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"grantGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"grantTokens\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"

            );


        bool isHavePass = await contract.Read<bool>("hasGameKey", Address);

        if (isHavePass == true)
        {
            playBtn.gameObject.SetActive(true);
            speedx2Btn.gameObject.SetActive(true);
            nftBtn.gameObject.SetActive(false);
        }
        else
        {
            playBtn.gameObject.SetActive(false);
            speedx2Btn.gameObject.SetActive(false);
            nftBtn.gameObject.SetActive(true);
        }
    }

    public async void GivePass()
    {
        Debug.Log("GivePass");
        nftBtn.interactable = false;
        nftBtnTxt.text = "Claiming Pass!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0x7aC00cc9868Ff562D3285918632563C41e5807f8",
            "[{\"type\":\"event\",\"name\":\"gameKeyGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"tokenGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"int256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"int256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getToken\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"int256\",\"name\":\"\",\"internalType\":\"int256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"grantGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"grantTokens\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );
        await contract.Write("grantGameKey", Address);

        nftBtn.interactable = true;
        nftBtnTxt.text = "Claim Pass To Play";

        playBtn.gameObject.SetActive(true);
        speedx2Btn.gameObject.SetActive(true);
        nftBtn.gameObject.SetActive(false);
    }

    public async void PlayGame()
    {
        Debug.Log("PlayGame");
        playBtn.interactable = false;
        speedx2Btn.interactable = false;
        playBtnText.text = "Preparing!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0x7aC00cc9868Ff562D3285918632563C41e5807f8",
            "[{\"type\":\"event\",\"name\":\"gameKeyGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"tokenGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"int256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"int256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getToken\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"int256\",\"name\":\"\",\"internalType\":\"int256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"grantGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"grantTokens\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );
        await contract.Write("grantTokens", Address);
        playBtn.interactable = true;
        speedx2Btn.interactable = true;
        playBtnText.text = "TAB TO PLAY";
        GameManager.Ins.PlayGame();
    }

    public async void x2Speed()
    {
        Debug.Log("x2Speed");
        playBtn.interactable = false;
        speedx2Btn.interactable = false;
        speedx2BtnText.text = "Claiming!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0x7aC00cc9868Ff562D3285918632563C41e5807f8",
            "[{\"type\":\"event\",\"name\":\"gameKeyGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"tokenGranted\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"int256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"int256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getToken\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"int256\",\"name\":\"\",\"internalType\":\"int256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"grantGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"grantTokens\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGameKey\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );
        await contract.Write("grantTokens", Address);
        playBtn.interactable = true;
        speedx2Btn.gameObject.SetActive(false);
        speedx2BtnText.text = "Double Speed";

        // Find the GameObject named Dino
        GameObject dinoObject = GameObject.Find("Dino");

        // Check if the dinoObject exists
        if (dinoObject != null)
        {
            // Get the Dino component from this GameObject
            Dino dinoScript = dinoObject.GetComponent<Dino>();

            // Check if the dinoScript exists
            if (dinoScript != null)
            {
                // Change the value of moveSpeed
                dinoScript.moveSpeed = 20f;
                Debug.Log("moveSpeed of Dino has been changed to 20.");
            }
            else
            {
                Debug.LogError("Dino script not found on the GameObject Dino.");
            }
        }
        else
        {
            Debug.LogError("GameObject named Dino not found.");
        }
    }

    public Button replayBtn;
    public Button homeBtn;
    public Button leaderboardBtn;
    public Text leaderboardBtnText;
    public Text GlobalLeaderboardText;


    public async void SubmitScore()
    {
        if (GameManager.Ins.Score <= 0) return;
        replayBtn.interactable = false;
        homeBtn.interactable = false;
        leaderboardBtn.interactable = false;
        leaderboardBtnText.text = "Submitting!";
        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0x86a88d7d4CcB7477Ce27E8138a83A5BF2B4426B3",
            "[{\"type\":\"event\",\"name\":\"ScoreAddedd\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"_scores\",\"inputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getRank\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"rank\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"submitScore\",\"inputs\":[{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"}]"
        );
        await contract.Write("submitScore", GameManager.Ins.Score);

        GetRank();
    }

    private async void GetRank()
    {
        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0x86a88d7d4CcB7477Ce27E8138a83A5BF2B4426B3",
            "[{\"type\":\"event\",\"name\":\"ScoreAddedd\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"_scores\",\"inputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getRank\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"rank\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"submitScore\",\"inputs\":[{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"}]"
        );
        var rank = await contract.Read<int>("getRank", Address);

        GlobalLeaderboardText.text = "Global Ranking: " + rank.ToString();
        leaderboardBtnText.text = "LEADERBOARD";
        replayBtn.interactable = true;
        homeBtn.interactable = true;
        leaderboardBtn.interactable = true;
    }
}
