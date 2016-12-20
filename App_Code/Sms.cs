using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for Sms
/// </summary>
public class Sms
{
    public Sms()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool _Vendor_Credit(string name, string phno, string Amt)
    {
        string msg = "Dear " + name + " Your Total Credit Amount Remaining Rs. " + Amt + " Thank You CRYSTAL PVT LTD";
        return _MSG(msg, phno);
    }

    public static bool _Vendor_Sale(string name, string phno, string Amt, string box)
    {
        //Dear XXXX Total Number of Box Delivered XXXX Amount XXXX Thank You XXXX
        string msg = "Dear " + name + " Total Number of Box Delivered " + box + " Amount Rs. " + Amt + " Thank You CRYSTAL PVT LTD";
        return _MSG(msg, phno);
    }
    
    public static bool _Vendor_Payment(string name, string phno, string rcvAmt, string dueAmt)
    {
        //Dear XXXX Amount Received XXXX Total Due XXXX . Thank You XXXX
        string msg = "Dear " + name + " Amount Received Rs. " + rcvAmt + " Total Due Rs. " + dueAmt + " . Thank You CRYSTAL PVT LTD";
        return _MSG(msg, phno);
    }
    public static bool _MSG(string Msg, string phno)
    {
        string strUrl = "";
        //Dear XXXX Your Total XXXX Amount Remaining XXXX Thank You XXXX
        //Dear XXXX Total Number of Box Delivered XXXX Amount XXXX Thank You XXXX
        strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=mukhtar@ssmaktak.com:mukhtar@1986&senderID=CRYSTL&receipientno=" + phno + "&dcs=0&msgtxt=" + Msg + "&state=4";

        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
        string[] a = dataString.Split(',');
        if (a[0].ToString() == "Status=0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool NewSubscriptionVoice(string phno)
    {
        string strUrl = "";
        //DEAR XXXX , (INFO TO VENDOR/DISTRIBUTOR)A TRAINING HAS BEEN SCHEDULED IN (ONLY VENDOR CITY) ON XXXX PLS. BUY YOUR PASS ASAP. TRAINGING DEPT.
        strUrl = "https://voiceapi.mvaayoo.com/voiceapi/SendVoice?user=mukhtar@ssmaktak.com:pintu786&da=" + phno + "&campaign_name=campaignname&voice_file=Orbiteer_1.wav";

        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
        string[] a = dataString.Split(',');
        if (a[0].ToString() == "Status=0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public static bool ENQUIRY(string phno, string vendorName, string city, string Time, string achieved, string lp, string code, int cond)
    {
        string strUrl = "";

        //DEAR XXXX , THANKS FOR YOUR ENQUIRY. OUR TEAM WILL CONTACT YOU SOON. ORBIT9X.

        strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=mukhtar@ssmaktak.com:pintu786&senderID=ORBITM&receipientno=" + phno + "&dcs=0&msgtxt=DEAR " + vendorName + " ,THANKS FOR YOUR ENQUIRY. OUR TEAM WILL CONTACT YOU SOON. ORBIT9X.&state=4 ";


        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
        string[] a = dataString.Split(',');
        if (a[0].ToString() == "Status=0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ForgotPassword(string phno)
    {
        string strUrl = "";
        //DEAR XXXX , (INFO TO VENDOR/DISTRIBUTOR)A TRAINING HAS BEEN SCHEDULED IN (ONLY VENDOR CITY) ON XXXX PLS. BUY YOUR PASS ASAP. TRAINGING DEPT.
        strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=mukhtar@ssmaktak.com:pintu786&senderID=ORBITM&receipientno=" + phno + "&dcs=0&msgtxt=Dear Vendor, We have sent a password reset link at your email address. Please click on the link to reset your password. Orbit9X&state=4 ";

        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
        string[] a = dataString.Split(',');
        if (a[0].ToString() == "Status=0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool ChangedPassword(string phno)
    {
        string strUrl = "";
        //DEAR XXXX , (INFO TO VENDOR/DISTRIBUTOR)A TRAINING HAS BEEN SCHEDULED IN (ONLY VENDOR CITY) ON XXXX PLS. BUY YOUR PASS ASAP. TRAINGING DEPT.
        strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=mukhtar@ssmaktak.com:pintu786&senderID=ORBITM&receipientno=" + phno + "&dcs=0&msgtxt=Dear Vendor, Your password changed successfully.&state=4 ";

        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
        string[] a = dataString.Split(',');
        if (a[0].ToString() == "Status=0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ForgotPassword1(string phno)
    {
        string strUrl = "";
        //DEAR XXXX , (INFO TO VENDOR/DISTRIBUTOR)A TRAINING HAS BEEN SCHEDULED IN (ONLY VENDOR CITY) ON XXXX PLS. BUY YOUR PASS ASAP. TRAINGING DEPT.
        strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=mukhtar@ssmaktak.com:pintu786&senderID=ORBITM&receipientno=" + phno + "&dcs=0&msgtxt=Dear Vendor, We have sent a password reset link to your email address. Click on the link to reset your Transaction Password.&state=4 ";

        WebRequest request = HttpWebRequest.Create(strUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();
        string[] a = dataString.Split(',');
        if (a[0].ToString() == "Status=0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}