using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;


     public class MailHelper
    {
        #region Global Variables

        MailMessage myMailMessage = null;
        SmtpClient mySmtpClient = null;
        AlternateView HtmlView = null;
        ICollection<System.Net.Mail.Attachment> myMailAttachments;
        protected ArrayList arr_image_path = new ArrayList();
        protected string RootDirectory = HttpRuntime.AppDomainAppPath.ToString();
        protected string myMailServer = string.Empty;
        protected string myMailToAddress = string.Empty;
        protected string myMailFromAddress = string.Empty;
        protected string myMailCCAddress = string.Empty;
        protected string myMailBCCAddress = string.Empty;
        protected string myMailSubject = string.Empty;
        protected string myMailBody = string.Empty;
        protected bool myMailIsBodyHtml = false;
        protected string myMailBodyHTMLFile = string.Empty;

        #endregion


        #region Properties

        public string MailServer
        {
            get
            {
                return myMailServer;
            }
            set
            {
                myMailServer = value;
            }
        }

        public string MailToAddress
        {
            get
            {
                return myMailToAddress;
            }
            set
            {
                myMailToAddress = value;
            }
        }

        public string MailFromAddress
        {
            get
            {
                return myMailFromAddress;
            }
            set
            {
                myMailFromAddress = value;
            }
        }

        public string MailCCAddress
        {
            get
            {
                return myMailCCAddress;
            }
            set
            {
                myMailCCAddress = value;
            }
        }

        public string MailBCCAddress
        {
            get
            {
                return myMailBCCAddress;
            }
            set
            {
                myMailBCCAddress = value;
            }
        }

        public string MailSubject
        {
            get
            {
                return myMailSubject;
            }
            set
            {
                myMailSubject = value;
            }
        }

        public string MailBody
        {
            get
            {
                return myMailBody;
            }
            set
            {
                myMailBody = value;
            }
        }

        public bool MailIsBodyHtml
        {
            get
            {
                return myMailIsBodyHtml;
            }
            set
            {
                myMailIsBodyHtml = value;
            }
        }

        public string MailBodyHTMLFile
        {
            get
            {
                return myMailBodyHTMLFile;
            }
            set
            {
                myMailBodyHTMLFile = value;
            }
        }

        public ICollection<System.Net.Mail.Attachment> MailAttachments
        {
            get
            {
                return myMailAttachments;
            }
            set
            {
                myMailAttachments = value;
            }
        }

        #endregion


        #region Methods

        public void SendMail()
        {
            try
            {
                myMailMessage = new MailMessage();
                mySmtpClient = new SmtpClient(this.MailServer);

                if (this.MailBodyHTMLFile != "" && this.myMailBody == "")
                {
                    this.myMailBody = retHTMLContent(myMailBodyHTMLFile);
                }

                if (this.MailToAddress != "") { myMailMessage.To.Add(this.MailToAddress); }
                if (this.MailCCAddress != "") { myMailMessage.CC.Add(this.MailCCAddress); }
                if (this.MailBCCAddress != "") { myMailMessage.Bcc.Add(this.MailBCCAddress); }
                if (this.MailFromAddress != "") { myMailMessage.From = new MailAddress(this.MailFromAddress); }
                if (this.MailSubject != "") { myMailMessage.Subject = Convert.ToString(this.MailSubject).Trim(); }

                if (this.MailAttachments != null)
                {
                    foreach (System.Net.Mail.Attachment attachment in this.MailAttachments)
                    {
                        myMailMessage.Attachments.Add(attachment);
                    }
                }

                if (this.MailIsBodyHtml == true)
                {
                    this.myMailBody = myMailBody.Replace(@"""", "'");

                    try
                    {
                        string AltString = covert_image_to_embedded_cid(this.MailBody);
                        HtmlView = AlternateView.CreateAlternateViewFromString(AltString, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
                        myMailMessage.AlternateViews.Add(HtmlView);

                        //add images
                        if (arr_image_path.Count > 0)
                        {
                            for (int i = 0; i < arr_image_path.Count; i++)
                            {
                                string img = arr_image_path[i].ToString();

                                if (!img.ToLower().StartsWith("http"))
                                {
                                    img = RootDirectory + img;
                                }

                                LinkedResource logo = new LinkedResource(img);
                                logo.ContentId = "EmbedRes_" + i;
                                HtmlView.LinkedResources.Add(logo);
                            }
                        }

                        myMailMessage.IsBodyHtml = true;
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
                else
                {
                    if (this.MailBody != "") { myMailMessage.Body = Convert.ToString(this.MailBody).Trim(); }
                }

                if (this.MailServer != "") { mySmtpClient.Send(myMailMessage); }
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Error in send mail !');</script>");
                throw (ex);
            }
            finally
            {
                myMailMessage = null;
                mySmtpClient = null;
                //System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Mail send successfully !');</script>");
            }
        }

        protected string covert_image_to_embedded_cid(string _html)
        {
            int cid = 0;
            string img_path;
            string Pattern = @"url\(['|\""]+.*['|\""]\)|src=[""|'][^""']+[""|']";


            MatchCollection match_vars = Regex.Matches(_html, Pattern, RegexOptions.IgnoreCase);

            foreach (Match match in match_vars)
            {
                _html = _html.Replace(match.Value, "src=\"cid:EmbedRes_" + cid + "\"");

                //get path;
                img_path = Regex.Replace(match.Value, @"url\(['|\""]", "");
                img_path = Regex.Replace(img_path, @"src=['|\""]", "");
                img_path = Regex.Replace(img_path, @"['|\""]\)", "").Replace("\'", "");

                arr_image_path.Add(img_path);
                cid++;
            }

            return _html;
        }

        protected string retHTMLContent(string HTMLFilePath)
        {
            string retString = string.Empty;
            TextReader txtReader = null;

            try
            {
                txtReader = new StreamReader(HttpContext.Current.Server.MapPath(HTMLFilePath));
                retString = Convert.ToString(txtReader.ReadToEnd());
                txtReader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                txtReader = null;
            }
            return retString;
        }

        #endregion
    }

