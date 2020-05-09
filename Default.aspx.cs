using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    DataAcces_Layer dal = new DataAcces_Layer();
    DataTable dt = new DataTable();
    bool opt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        try
        {
            dt = dal.Selectdata("select * from books");
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dal.Repairconnection();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            dt = dal.Selectdata("select * from books where title = '" + txtTitle.Text + "' and isbn = '" + txtIsbn.Text + "'");
            if (dt.Rows.Count > 0)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Book Already Exists!!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                dal.Repairconnection();
                opt = dal.ExecuteSql("insert into books values('" + txtTitle.Text + "', '" + txtAuthor.Text + "', '" + txtIsbn.Text + "', '" + txtPublisher.Text + "', '" + txtYear.Text + "')");
                if (opt == true)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Book Inserted Successfully!!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    dal.Repairconnection();
                    bind();
                    txtTitle.Text = "";
                    txtAuthor.Text = "";
                    txtIsbn.Text = "";
                    txtPublisher.Text = "";
                    txtYear.Text = "";
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Please Try Again Later!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Server Not Respond!!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            dal.Repairconnection();
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        try
        {
            dal.Repairconnection();
            opt = dal.ExecuteSql("update books set title = '" + txtTitle.Text + "', author = '" + txtAuthor.Text + "', isbn = '" + txtIsbn.Text + "', publisher = '" + txtPublisher.Text + "', year = '" + txtYear.Text + "' where slno = '" + ViewState["id"].ToString() + "'");
            if (opt == true)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Book Details Updated Successfully!!";
                lblmsg.ForeColor = System.Drawing.Color.Green;

                dal.Repairconnection();
                bind();
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please Try Again Later!!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Server Not Respond!!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            dal.Repairconnection();
        }
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                HiddenField HiddenField1 = (HiddenField)row.Cells[0].FindControl("HiddenField1");
                Label lblTitle = (Label)row.Cells[1].FindControl("lblTitle");
                Label lblAuthor = (Label)row.Cells[2].FindControl("lblAuthor");
                Label lblIsbn = (Label)row.Cells[2].FindControl("lblIsbn");
                Label lblPublisher = (Label)row.Cells[2].FindControl("lblPublisher");
                Label lblYear = (Label)row.Cells[2].FindControl("lblYear");
                ViewState["id"] = HiddenField1.Value;

                txtTitle.Text = lblTitle.Text;
                txtAuthor.Text = lblAuthor.Text;
                txtIsbn.Text = lblIsbn.Text;
                txtPublisher.Text = lblPublisher.Text;
                txtYear.Text = lblYear.Text;

                btnSave.Visible = false;
                btnModify.Visible = true;
                btnCancel.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Server Not Respond!!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            HiddenField id = (HiddenField)GridView1.Rows[e.RowIndex].Cells[0].FindControl("HiddenField1");
            dal.Repairconnection();
            opt = dal.ExecuteSql("delete from books where slno='" + id.Value + "'");
            if (opt == true)
            {
                lblmsg.Text = "Book Deleted Successfully!!";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                dal.Repairconnection();
                bind();
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Try Again Later!!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Server Not Respond!!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            dal.Repairconnection();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTitle.Text = "";
        txtAuthor.Text = "";
        txtIsbn.Text = "";
        txtPublisher.Text = "";
        txtYear.Text = "";
        btnSave.Visible = true;
        btnModify.Visible = false;
        btnCancel.Visible = false;
    }
}