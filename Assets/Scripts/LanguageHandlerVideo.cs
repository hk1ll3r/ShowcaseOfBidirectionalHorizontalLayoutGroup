﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using NoSuchStudio.UI;

public class LanguageHandlerVideo : MonoBehaviour
{
    [SerializeField] private Toggle toggleEnglish;
    [SerializeField] private Toggle toggleArabic;
    [SerializeField] private Toggle toggleSpanish;
    [SerializeField] private Toggle togglePersian;

    [SerializeField] private TextMeshProUGUI textBack;
    [SerializeField] private TextMeshProUGUI textTitle;

    // [SerializeField] private BidirHorizontalLayoutGroup panelTitle;
    [SerializeField] private HorizontalLayoutGroup panelTitle;

    private Toggle[] allToggles;

    private static Dictionary<string, string> backTexts = new Dictionary<string, string>() {
        ["en"] = "kcaB",
        ["fa"] = "ﺑﺎزﮔﺸﺖ",
        ["es"] = "sárta",
        ["ar"] = "ﻋﻮدة",
    };
    private static Dictionary<string, string> titleTexts = new Dictionary<string, string>() {
        ["en"] = "egaP sgnitteS",
        ["fa"] = "ﺻﻔﺤﻪ ﺗﻨﻈﯿﻤﺎت",
        ["ar"] = "ﺻﻔﺤﺔ إﻋﺪادات",
        ["es"] = "nóicarugifnoc ed anigáP",
    };
    void Awake() {
        allToggles = new Toggle[] {
            toggleEnglish,
            toggleArabic,
            toggleSpanish,
            togglePersian
        };
    }

    void Start()
    {
        SyncWithToggles();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            ScreenCapture.CaptureScreenshot(string.Format("debug-screenshot-{0}.png", DateTime.Now.ToString("yyyyMMddHHmmss")));
        }
    }


    private void SyncWithToggles() {
        /*bool rtl = true;
        if (toggleEnglish.isOn || toggleSpanish.isOn) {
            rtl = false;
        }
        foreach (Toggle t in allToggles) {
            BidirHorizontalLayoutGroup bidirLayoutGroup = t.GetComponent<BidirHorizontalLayoutGroup>();
            bidirLayoutGroup.IsReverse = rtl;
            //bidirLayoutGroup.childAlignment = rtl ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
        }
        panelTitle.IsReverse = rtl;*/
        

        if (toggleEnglish.isOn) {
            textBack.text = backTexts["en"];
            textTitle.text = titleTexts["en"];
        } else if (toggleArabic.isOn) {
            textBack.text = backTexts["ar"];
            textTitle.text = titleTexts["ar"];
        } else if (toggleSpanish.isOn) {
            textBack.text = backTexts["es"];
            textTitle.text = titleTexts["es"];
        } else if (togglePersian.isOn) {
            textBack.text = backTexts["fa"];
            textTitle.text = titleTexts["fa"];
        }

    }

    public void OnToggleClick(bool b) {
        if (b) {
            SyncWithToggles();
        }
    }
}
