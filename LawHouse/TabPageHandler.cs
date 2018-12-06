﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using DataClassLib;

namespace GUI
{
    class TabPageHandler
    {
        //Julius - New Code
        public void MakeNewTabs() // Proof-Of-Concept
        {
            TabControl thisTabControl;
            TabPage basicTabPage;

            thisTabControl = new TabControl(); // ny TabControl
            basicTabPage = new TabPage(); // ny TabPage

            //thisTabControl.Controls.Add(basicTabPage);

            TabPage advancedTabPage;
            advancedTabPage = basicTabPage; //sætter den nye til at være den samme
            //advancedTabPage = (stuff+advancedTabPage)
            thisTabControl.Controls.Add(advancedTabPage);
            // [...]
            //nu vil vi gerne opdatere
            TabPage newAdvancedTabPage;
            newAdvancedTabPage = basicTabPage;
            //newAdvancedTabPage = (stuff+newAdvancedTabPage)
            int targetLocation = thisTabControl.TabPages.IndexOf(advancedTabPage);
            thisTabControl.TabPages.Remove(advancedTabPage);
            thisTabControl.TabPages.Insert(targetLocation, newAdvancedTabPage);

            //UnifiedGuiForm.Controls.Add(thisTabControl); //Tilføjer tabcontrol til formen
        }

        public void makeNewTabPageController()
        {
            List<string> keyOfNewTabs = new List<string>();
            keyOfNewTabs.Add("Sag");
            keyOfNewTabs.Add("Advokat");
            keyOfNewTabs.Add("Klient");
            keyOfNewTabs.Add("Ydelse");
            Dictionary<string, string> tabsToAdd = ReturnTabsToAdd(keyOfNewTabs);

            foreach (string currentKey in keyOfNewTabs)
            {
                string currentValue = tabsToAdd[currentKey];
                TabPage newPage = LoadNewTabPageFromTemplate(currentKey, currentValue);
                ReplaceTabPage(newPage);
            }
        }
        private Dictionary<string, string> ReturnTabsToAdd(List<String> tabsToAdd)
        {
            Dictionary<string, string> dictionaryOfNewTabs;
            dictionaryOfNewTabs = new Dictionary<string, string>();
            foreach (string Key in tabsToAdd)
            {
                dictionaryOfNewTabs.Add(("tab" + Key), Key);
            }
            return dictionaryOfNewTabs;
        }
        private void ReplaceTabPage(TabPage newPage)
        {
            int targetLocation;
            try
            {
                targetLocation = UnifiedGuiForm.DynamicTabControl.TabPages.IndexOfKey(newPage.Name);
                UnifiedGuiForm.DynamicTabControl.TabPages.RemoveByKey(newPage.Name);
            }
            catch (Exception e)
            {
                targetLocation = UnifiedGuiForm.DynamicTabControl.TabPages.Count;
                throw new Exception("No TAb Found by That Name, making new tab");
            }
            UnifiedGuiForm.DynamicTabControl.TabPages.Insert(targetLocation, newPage);
        }
        private TabPage LoadNewTabPageFromTemplate(string TabName, string TabText)
        {
            TabPage newTabPage = new TabPage();
            TabBuilderHelper(newTabPage);
            newTabPage.Name = TabName;
            newTabPage.Text = TabText;
            return newTabPage;
        }
        private void TabBuilderHelper(TabPage newTabPage) //Her puttes constructoren ind
        {

        }


        //Virker ikke da TabPage virker som en REFERANCE og ikke et object
        /*
        public void SetTabs()
        {
            TabPage basicTabPage;
            basicTabPage = CreateDefaultTabPage();

            TabPage tabSag = CreateTabPageFromTemplate(basicTabPage);
            tabSag.Text = "Sag";
            tabSag.Name = ("tab" + tabSag.Text);
            ReplaceTabPage(tabSag);

            TabPage tabAdvokat = CreateTabPageFromTemplate(basicTabPage);
            tabSag.Text = "Advokat";
            tabSag.Name = ("tab" + tabSag.Text);
            ReplaceTabPage(tabAdvokat);

            TabPage tabKlient = CreateTabPageFromTemplate(basicTabPage);
            tabSag.Text = "Klient";
            tabSag.Name = ("tab" + tabSag.Text);
            ReplaceTabPage(tabKlient);

            TabPage tabYdelse = CreateTabPageFromTemplate(basicTabPage);
            tabSag.Text = "Ydelse";
            tabSag.Name = ("tab" + tabSag.Text);
            ReplaceTabPage(tabYdelse);
        }

        private void ReplaceTabPage(TabPage newPage)
        {
            int targetLocation = DynamicTabControl.TabPages.IndexOfKey(newPage.Name);
            DynamicTabControl.TabPages.RemoveByKey(newPage.Name);
            DynamicTabControl.TabPages.Insert(targetLocation, newPage);
        }
        private TabPage CreateDefaultTabPage()
        {
            TabPage basicTabPage = new TabPage();
            //
            basicTabPage = tabClickHereFirst;
            //
            return basicTabPage;
        }
        private TabPage CreateTabPageFromTemplate(TabPage template)
        {
            TabPage newPage;
            newPage = template;
            return newPage;
        }
        */
    }
}
