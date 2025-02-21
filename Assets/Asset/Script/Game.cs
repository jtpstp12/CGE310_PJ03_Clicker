using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // เพิ่มการใช้งาน TextMeshPro
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("1"); // โหลดซีน MainMenu
    }

    public TMP_Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    //shop
    public int shop1prize;
    public TMP_Text shop1text;

    public int shop2prize;
    public TMP_Text shop2text;

    public int shop3prize;
    public TMP_Text shop3text;

    //amount
    public TMP_Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public TMP_Text amount2Text;
    public int amount2;
    public float amount2Profit;

    public TMP_Text amount3Text;
    public int amount3;
    public float amount3Profit;

    public TMP_Text totalProfitText;
    public TMP_Text hitPowerText; // ตัวแปรสำหรับแสดงค่า Hit Power

    //upgrade
    public int upgradePrize;
    public TMP_Text upgradeText;

    public int allUpgradePrize;
    public TMP_Text AllUpgradeText;

    public GameObject plusObject;
    public TMP_Text plusText;

    void Start()
    {
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;
        allUpgradePrize = 700;

        if (PlayerPrefs.GetInt("isLoading", 0) == 1) // เช็คว่ากด Load Game มาหรือไม่
        {
            LoadGame();
            PlayerPrefs.SetInt("isLoading", 0); // รีเซ็ตค่า
        }
    }

    void Update()
    {
        scoreText.text = ((int)currentScore).ToString() + " $";
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasedPerSecond;

        float totalProfit = amount1Profit + amount2Profit + amount3Profit; // แก้สูตรคำนวณ
        totalProfitText.text = "Total: " + totalProfit + " $/s";

        hitPowerText.text = "Hit Power: " + hitPower;

        shop1text.text = shop1prize + " $";
        shop2text.text = shop2prize + " $";
        shop3text.text = shop3prize + " $";

        amount1Text.text = "Lvl: " + amount1 + " $: " + amount1Profit + "/s";
        amount2Text.text = "Lvl: " + amount2 + " $: " + amount2Profit + "/s";
        amount3Text.text = "Lvl: " + amount3 + " $: " + amount3Profit + "/s";

        upgradeText.text = upgradePrize + " $";
        AllUpgradeText.text = "Cost: " + allUpgradePrize + " $";

        plusText.text = "+ " + hitPower;
    }

    public void Hit()
    {
        currentScore += hitPower;
        plusObject.SetActive(false);
        plusObject.transform.position = new Vector3(Random.Range(465, 645 + 1), Random.Range(205, 405 + 1), 0);
        plusObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(Fly());
    }

    public void Shop1()
    {
        if (currentScore >= shop1prize)
        {
            currentScore -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize *= 2;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2prize)
        {
            currentScore -= shop2prize;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2prize *= 2;
        }
    }

    public void Shop3()
    {
        if (currentScore >= shop3prize)
        {
            currentScore -= shop3prize;
            amount3 += 1;
            amount3Profit += 15;
            x += 10;
            shop3prize *= 2;
        }
    }

    public void Upgrade()
    {
        if (currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 3;
        }
    }

    public void AllProfitUpgrade()
    {
        if (currentScore >= allUpgradePrize)
        {
            currentScore -= allUpgradePrize;
            x *= 2;
            allUpgradePrize *= 3;
            amount1Profit *= 2;
            amount2Profit *= 2;
        }
    }

    IEnumerator Fly()
    {
        for (int i = 0; i <= 19; i++)
        {
            yield return new WaitForSeconds(0.01f);
            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + 2, 0);
        }
        plusObject.SetActive(false);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("currentScore", currentScore);
        PlayerPrefs.SetFloat("hitPower", hitPower);
        PlayerPrefs.SetFloat("x", x);

        PlayerPrefs.SetInt("amount1", amount1);
        PlayerPrefs.SetFloat("amount1Profit", amount1Profit);
        PlayerPrefs.SetInt("amount2", amount2);
        PlayerPrefs.SetFloat("amount2Profit", amount2Profit);
        PlayerPrefs.SetInt("amount3", amount3);
        PlayerPrefs.SetFloat("amount3Profit", amount3Profit);

        PlayerPrefs.SetInt("shop1prize", shop1prize);
        PlayerPrefs.SetInt("shop2prize", shop2prize);
        PlayerPrefs.SetInt("shop3prize", shop3prize);
        PlayerPrefs.SetInt("upgradePrize", upgradePrize);
        PlayerPrefs.SetInt("allUpgradePrize", allUpgradePrize);

        PlayerPrefs.Save();
        Debug.Log("💾 เกมถูกบันทึกแล้ว!");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("currentScore"))
        {
            currentScore = PlayerPrefs.GetFloat("currentScore");
            hitPower = PlayerPrefs.GetFloat("hitPower");
            x = PlayerPrefs.GetFloat("x");

            amount1 = PlayerPrefs.GetInt("amount1");
            amount1Profit = PlayerPrefs.GetFloat("amount1Profit");
            amount2 = PlayerPrefs.GetInt("amount2");
            amount2Profit = PlayerPrefs.GetFloat("amount2Profit");
            amount3 = PlayerPrefs.GetInt("amount3");
            amount3Profit = PlayerPrefs.GetFloat("amount3Profit");
        }
        else
        {
            Debug.Log("❌ ไม่มีข้อมูลเซฟ");
        }
    }
}
