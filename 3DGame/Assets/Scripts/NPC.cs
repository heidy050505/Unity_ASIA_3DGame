using UnityEngine;
using UnityEngine.UI;
using System.Collections;  //引用 系統.集合 API(包含協同程序)

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;

    /// <summary>
    /// 玩家是否進入感應區
    /// </summary>
    public bool playerInArea;

    //定義列舉 enum(下拉式選單-只能選一個)
    public enum NPCState
    {
        FristDialog, Missioning, Finish
    }
    //列舉欄位
    //修飾詞 列舉名稱 自訂欄位名稱 指定 預設值;
    public NPCState state = NPCState.FristDialog;

    /* 協同程序
    private void Start()
    {
        //啟動協同程序
        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        print("嗨");
        yield return new WaitForSeconds(1.5f);
        print("一點五秒後");
        yield return new WaitForSeconds(2);
        print("兩秒後");
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Robot Kyle")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Robot Kyle")
        {
            playerInArea = false;
            StopDialog();
        }
    }
    /// <summary>
    /// 停止對話
    /// </summary>
    private void StopDialog()
    {
        dialog.SetActive(false);  //關閉對話框
        StopAllCoroutines();    // 停止所有協程
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    /// <returns></returns>
    private IEnumerator Dialog()
    {
        //顯示對話框
        dialog.SetActive(true);
        //清空文字
        textContent.text = "";

        textName.text = name;

        /**
        //print(data.dialougA);    取得字串全部資料
        //print(data.dialougA);   取得字串局部資料：語法[編號]

        //Length 字串的長度
        */
        //要說的對話
        string dialogString = data.dialougA;

        switch (state)
        {
            case NPCState.FristDialog:
                dialogString = data.dialougA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialougB;
                break;
            case NPCState.Finish:
                dialogString = data.dialougC;
                break;
        }

        for (int i = 0; i< dialogString.Length; i++)
	    {
            //print(data.dialougA[i]);
            //文字串聯
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
	    }
    }


}
