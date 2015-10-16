using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Lync.Model;
using System.Drawing;
using System.IO;

namespace ConsoleApplication1
{
 

    class Program
    {
       /*
        #region StackOverflowTry1
        private List<Outlook.ContactItem> GetListOfContacts(Outlook._Application OutlookApp)
        {
            List<Outlook.ContactItem> contactItemsList = null;
            Outlook.Items folderItems = null;
            Outlook.MAPIFolder folderSuggestedContacts = null;
            Outlook.NameSpace ns = null;
            Outlook.MAPIFolder folderContacts = null;
            object itemObj = null;
            try
            {
                contactItemsList = new List<Outlook.ContactItem>();
                ns = OutlookApp.GetNamespace("MAPI");
                // getting items from the Contacts folder in Outlook
                folderContacts = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
                folderItems = folderContacts.Items;
                for (int i = 1; folderItems.Count >= i; i++)
                {
                    itemObj = folderItems[i];
                    if (itemObj is Outlook.ContactItem)
                        contactItemsList.Add(itemObj as Outlook.ContactItem);
                    else
                        Marshal.ReleaseComObject(itemObj);
                }
                Marshal.ReleaseComObject(folderItems);
                folderItems = null;
                // getting items from the Suggested Contacts folder in Outlook
                folderSuggestedContacts = ns.GetDefaultFolder(
                                          Outlook.OlDefaultFolders.olFolderSuggestedContacts);
                folderItems = folderSuggestedContacts.Items;
                for (int i = 1; folderItems.Count >= i; i++)
                {
                    itemObj = folderItems[i];
                    if (itemObj is Outlook.ContactItem)
                        contactItemsList.Add(itemObj as Outlook.ContactItem);
                    else
                        Marshal.ReleaseComObject(itemObj);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (folderItems != null)
                    Marshal.ReleaseComObject(folderItems);
                if (folderContacts != null)
                    Marshal.ReleaseComObject(folderContacts);
                if (folderSuggestedContacts != null)
                    Marshal.ReleaseComObject(folderSuggestedContacts);
                if (ns != null) Marshal.ReleaseComObject(ns);
            }
            return contactItemsList;
        }
        #endregion
        */

        /*
        static void Main(string[] args)
        {
            
        }
        */
        void help()
        {
            LyncClient client = LyncClient.GetClient();

            if (client != null)
            {
                ContactManager cManager = client.ContactManager;
                if (cManager != null)
                {
                    Contact contact = cManager.GetContactByUri("useremail@domain.com");
                    if (contact != null)
                    {
                        List<ContactInformationType> ciList = new List<ContactInformationType>();
                        ciList.Add(ContactInformationType.Photo);
                        IDictionary<ContactInformationType, object> dic = null;
                        dic = contact.GetContactInformation(ciList);
                        if (dic != null)
                        {
                            Stream photoStream = dic[ContactInformationType.Photo] as Stream;
                            if (photoStream != null)
                            {
                                StreamReader sr = new StreamReader(photoStream);
                                string text = sr.ReadToEnd();
                                
                            }
                        }
                    }
                }
            }

            /*
                        Microsoft.Office.Interop.Outlook.Application outlook;
                        outlook = new Microsoft.Office.Interop.Outlook.Application();

                        Microsoft.Office.Interop.Outlook.MAPIFolder folder;
                        folder = outlook.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                        IEnumerable<ContactItem> contacts = folder.Items.OfType<ContactItem>();

                        var query = from contact in contacts
                                    where contact.Email1Address != null
                                    select contact;

            

                        foreach (var contact in query)
                        {
                            string picturePath = "";
                
                            if (contact.HasPicture)
                                foreach (Microsoft.Office.Interop.Outlook.Attachment att in contact.Attachments)
                                {
                                    if (att.DisplayName == "ContactPicture.jpg")
                                    {
                                        try
                                        {
                                            string path = System.IO.Path.GetTempPath();
                                            picturePath = System.IO.Path.GetDirectoryName(path) + "\\Contact_" + contact.EntryID + ".jpg";
                                            if (!System.IO.File.Exists(picturePath))
                                                att.SaveAsFile(picturePath);
                                        }
                                        catch
                                        {
                                            picturePath = "";
                                        }
                                    }
                                }
                    
                    
                    
                                //contact.Attachments["ContactPicture.jpg"].SaveAsFile(@"C:\Users\smardalo\Desktop\ContactPicture.jpg");       
                        }
                    */
        }

        void help2()
        {
            LyncClient client = LyncClient.GetClient();
            Console.WriteLine(client.State);

            if (client != null)
            {
                ContactManager cManager = client.ContactManager;
                if (cManager != null)
                {
                    Contact contact = cManager.GetContactByUri("serban.mardaloescu@misys.com");
                    if (contact != null)
                    {
                        List<ContactInformationType> ciList = new List<ContactInformationType>();
                        ciList.Add(ContactInformationType.Photo);
                        IDictionary<ContactInformationType, object> dic = null;
                        int i = 0;
                        foreach (var group in cManager.Groups)
                        {
                            foreach (var cont in group)
                            {
                                Contact c = cManager.GetContactByUri(cont.Uri);
                                System.Console.WriteLine(c.GetContactInformation(ContactInformationType.Photo));

                                /*if((cont.GetContactInformation(ContactInformationType.Photo) as Stream) != null)
                                    Image.FromStream(cont.GetContactInformation(ContactInformationType.Photo) as Stream).Save("phote" + i++ + ".png");
                                */
                                System.Console.WriteLine(cont.Uri);
                            }

                        }
                        System.Console.ReadLine();
                        dic = contact.GetContactInformation(ciList);
                        if (dic != null)
                        {
                            Image.FromStream(client.Self.Contact.GetContactInformation(ContactInformationType.Photo) as Stream).Save("phote.png");

                        }
                    }
                }
            }
            
        }
    
    }
}
