using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : Object
{
    private string title;
    private string information;

    public Quest(string title = "タイトルなし", string info = "内容なし")
    {
        this.title = title;
        this.information = info;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetInformation()
    {
        return information;
    }
}
