using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebColiber
{
    public partial class DeleteFromBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string order = Request.QueryString["orders"];

            if (order != null && order.Length > 0)
            {
                List<string> OrdersList = Session["orders"] as List<string>;
                List<string> OrdersMagList = Session["ordersMag"] as List<string>;

                order = order.Replace("{", "").Replace("}", "");
                List<string> orders = order.Split(',').Distinct().ToList();

                foreach (string delete in orders)
                {
                    if (delete.Contains('b'))
                    {
                        string tmp = delete.Replace("b", "");
                        
                        if (OrdersList.Contains(tmp))
                            OrdersList.Remove(tmp);
                    }
                    else if (delete.Contains('m'))
                    {
                        string tmp = delete.Replace("m", "");

                        if (OrdersMagList.Contains(tmp))
                            OrdersMagList.Remove(tmp);
                    }
                }

                Session["orders"] = OrdersList;
                Session["ordersMag"] = OrdersMagList;
            }

            Response.Redirect("Basket.aspx");
        }
    }
}