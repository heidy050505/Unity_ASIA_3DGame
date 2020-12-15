using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    /// <summary>
    /// 玩家是否進入感應區
    /// </summary>
    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Robot Kyle")
        {
            playerInArea = true;
            Dialog();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Robot Kyle")
        {
            playerInArea = false;
        }
    }

    private void Dialog()
    {
        //print(data.dialougA);    取得字串全部資料
        //print(data.dialougA);   取得字串局部資料：語法[編號]

        //Length 字串的長度
        for (int i = 0; i< data.dialougA.Length; i++)
	    {
            print(data.dialougA[i]);
	    }
    }


}
