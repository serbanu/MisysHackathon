using System;
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace OutlookAddIn22
{
    public partial class ThisAddIn
    {
        Outlook.SolutionsModule solutionsModule;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Call EnsureSolutionsModule to ensure that
            //Solutions module and custom folder icons
            //appear in Outlook Navigation Pane
            EnsureSolutionsModule();
        }


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            //If needed, your cleanup code goes here
        }


private void EnsureSolutionsModule()
{
    try
    {
        //Declarations
        Outlook.Folder solutionRoot;
        Outlook.Folder solutionCalendar;
        Outlook.Folder solutionContacts;
        Outlook.Folder solutionTasks;
        bool firstRun = false ;
        Outlook.Folder rootStoreFolder =
            Application.Session.DefaultStore.GetRootFolder()
            as Outlook.Folder;
        //If solution root folder does not exist, create it
        //Note that solution root 
        //could also be in PST or custom store
        try
        {
            solutionRoot =
                rootStoreFolder.Folders["Birthday Calendar"]
                as Outlook.Folder;
        }
        catch
        {
            firstRun = true;
        }

        if (firstRun == true)
        {
            solutionRoot =
                rootStoreFolder.Folders.Add("Birthday Calendar",
                Outlook.OlDefaultFolders.olFolderInbox) 
                as Outlook.Folder;
            solutionCalendar = solutionRoot.Folders.Add(
                "Solution Calendar", 
                Outlook.OlDefaultFolders.olFolderCalendar)
                as Outlook.Folder;
            solutionContacts = solutionRoot.Folders.Add(
                "Solution Contacts", 
                Outlook.OlDefaultFolders.olFolderContacts)
                as Outlook.Folder;
            solutionTasks = solutionRoot.Folders.Add(
                "Solution Tasks", 
                Outlook.OlDefaultFolders.olFolderTasks)
                as Outlook.Folder;
        }
        else
        {
            solutionRoot =
                rootStoreFolder.Folders["Birthday Calendar"]
                as Outlook.Folder;
            solutionCalendar = solutionRoot.Folders[
                "Solution Calendar"]
                as Outlook.Folder;
            solutionContacts = solutionRoot.Folders[
                "Solution Contacts"]
                as Outlook.Folder;
            solutionTasks = solutionRoot.Folders[
                "Solution Tasks"]
                as Outlook.Folder;
        } 
        //Get the icons for the solution
        stdole.StdPicture rootPict = 
            PictureDispConverter.ToIPictureDisp(
            OutlookAddIn22.Properties.Resources.BRIDGE)
            as stdole.StdPicture;
        stdole.StdPicture calPict = 
            PictureDispConverter.ToIPictureDisp(
            OutlookAddIn22.Properties.Resources.umbrella)
            as stdole.StdPicture;
        stdole.StdPicture contactsPict = 
            PictureDispConverter.ToIPictureDisp(
            OutlookAddIn22.Properties.Resources.group)
            as stdole.StdPicture;
        stdole.StdPicture tasksPict = 
            PictureDispConverter.ToIPictureDisp(
            OutlookAddIn22.Properties.Resources.SUN)
            as stdole.StdPicture;
        //Set the icons for solution folders
        solutionRoot.SetCustomIcon(rootPict);
        solutionCalendar.SetCustomIcon(calPict);
        solutionContacts.SetCustomIcon(contactsPict);
        solutionTasks.SetCustomIcon(tasksPict);
        //Obtain a reference to the SolutionsModule
        Outlook.Explorer explorer = Application.ActiveExplorer();
        solutionsModule =
            explorer.NavigationPane.Modules.GetNavigationModule(
            Outlook.OlNavigationModuleType.olModuleSolutions)
            as Outlook.SolutionsModule;
        //Add the solution and hide folders in default modules
        solutionsModule.AddSolution(solutionRoot, 
            Outlook.OlSolutionScope.olHideInDefaultModules);
        //The following code sets the position and visibility
        //of the SolutionsModule
        if (solutionsModule.Visible == false)
        {
            //Set Visibile to true
            solutionsModule.Visible = true;
        }
        if (solutionsModule.Position != 5)
        {
            //Move SolutionsModule to Position = 5
            solutionsModule.Position = 5;
        }
        //Create instance variable for Outlook.NavigationPane
        Outlook.NavigationPane navPane = explorer.NavigationPane;
        if (navPane.DisplayedModuleCount != 5)
        {
            //Ensure that Solutions Module button is large
            navPane.DisplayedModuleCount = 5;
        }
    }
    catch (System.Exception ex)
    {
        Debug.Write(ex.Message);
    }
}
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
