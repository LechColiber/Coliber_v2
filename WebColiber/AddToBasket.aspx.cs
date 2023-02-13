using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace WebColiber
{
    public partial class AddToBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string order = Request.QueryString["orders"];
            if (order != null && order.Length > 0)
            {
                order = order.Replace("{", "").Replace("}", "");
                List<string> orders = order.Split(',').Distinct().Where(x => Regex.IsMatch(x, @"^\d+$")).ToList();
                List<string> oldOrders = Session["orders"] as List<string>;

                if (oldOrders != null)
                    orders = orders.Concat(oldOrders).ToList();

                Session["orders"] = orders;
            }

            order = Request.QueryString["ordersMag"];
            if (order != null && order.Length > 0)
            {
                order = order.Replace("{", "").Replace("}", "");
                List<string> orders = order.Split(',').Distinct().Where(x => Regex.IsMatch(x, @"^\d+$")).ToList();
                List<string> oldOrders = Session["ordersMag"] as List<string>;

                if (oldOrders != null)
                    orders = orders.Concat(oldOrders).ToList();

                Session["ordersMag"] = orders;
            }

            order = Request.QueryString["ordersNor"];
            if (order != null && order.Length > 0)
            {
                order = order.Replace("{", "").Replace("}", "");
                List<string> orders = order.Split(',').Distinct().Where(x => Regex.IsMatch(x, @"^\d+$")).ToList();
                List<string> oldOrders = Session["ordersNor"] as List<string>;

                if (oldOrders != null)
                    orders = orders.Concat(oldOrders).ToList();

                Session["ordersNor"] = orders;
            }

            Response.Redirect("Basket.aspx");            
        }
    }
}