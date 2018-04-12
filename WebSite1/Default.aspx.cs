using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e){}

	protected void Button1_Click(object sender, EventArgs e)
	{
		// Get and display IP Address
		string ipAddress = GetLocalIPAddress();

		output.InnerHtml = "";
		output.InnerHtml += $"Ip address is: {ipAddress}";

		// Get City & State info
		CityStateCountByIp(ipAddress);

		// Display "Write Cookie Button"
		Button2.Visible = true;

	}

	public string GetLocalIPAddress()
	{
		var host = Dns.GetHostEntry(Dns.GetHostName());

		string externalip = new WebClient().DownloadString("http://icanhazip.com");
		return externalip;
	}

	public void CityStateCountByIp(string ip)
	{
		var url = "http://freegeoip.net/json/" + ip;
		var request = System.Net.WebRequest.Create(url);

		using (WebResponse wrs = request.GetResponse())
		using (Stream stream = wrs.GetResponseStream())
		using (StreamReader reader = new StreamReader(stream))
		{
			string json = reader.ReadToEnd();
			var obj = JObject.Parse(json);

			IP.State = (string)obj["region_name"];
			IP.City = (string)obj["city"];
			IP.IPAddress = ip;
		};

	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		// Write Cookie
		Response.Cookies["UserSettings"]["IP"] = IP.IPAddress;
		Response.Cookies["UserSettings"]["City"] = IP.City;
		Response.Cookies["UserSettings"]["State"] = IP.State;

		Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(1d);
	}
}

public static class IP
{
	public static string City { get; set; }
	public static string State { get; set; }
	public static string IPAddress { get; set; }
}