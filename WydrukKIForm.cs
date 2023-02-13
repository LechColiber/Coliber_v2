// Decompiled with JetBrains decompiler
// Type: Reports.WydrukKIForm
// Assembly: Reports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EABA3FB-B96C-4D63-9763-B5503E139195
// Assembly location: C:\Program\Exell\ColiberDLLs\Reports.dll

using Microsoft.Reporting.WinForms;
using RdlViewer;
using Reports.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Reports
{
  public class WydrukKIForm : Form
  {
    private Dictionary<int, string> SortByDictionary1 = new Dictionary<int, string>();
    private Dictionary<int, string> SortByDictionary2 = new Dictionary<int, string>();
    private IContainer components;
    private Label statsLabel;
    private Label label2;
    private PictureBox pictureBox1;
    private Label kindLabel;
    private Panel panel1;
    private DateTimePicker ToDTP;
    private Label endDateLabel;
    private DateTimePicker FromDTP;
    private Label startDateLabel;
    private ComboBox SortByComboBox;
    private Label sortByLabel;
    private ComboBox IdRodzajComboBox;
    private Label orInInvertoryLabel;
    private CheckBox AllDbCheckBox;
    private TextBox ValueTextBox;
    private Label startWithLabel;
    private ComboBox KindComboBox;
    private ComboBox ForAllComboBox;
    private Label forAllLabel;
    private Button SearchButton;
    private Button ExitButton;
    private CheckBox DateCheckBox;
    private Dictionary<string, string> _translationsDictionary;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (WydrukKIForm));
      this.statsLabel = new Label();
      this.label2 = new Label();
      this.pictureBox1 = new PictureBox();
      this.kindLabel = new Label();
      this.panel1 = new Panel();
      this.DateCheckBox = new CheckBox();
      this.ToDTP = new DateTimePicker();
      this.endDateLabel = new Label();
      this.FromDTP = new DateTimePicker();
      this.startDateLabel = new Label();
      this.SortByComboBox = new ComboBox();
      this.sortByLabel = new Label();
      this.IdRodzajComboBox = new ComboBox();
      this.orInInvertoryLabel = new Label();
      this.AllDbCheckBox = new CheckBox();
      this.ValueTextBox = new TextBox();
      this.startWithLabel = new Label();
      this.KindComboBox = new ComboBox();
      this.ForAllComboBox = new ComboBox();
      this.forAllLabel = new Label();
      this.SearchButton = new Button();
      this.ExitButton = new Button();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.statsLabel.AutoSize = true;
      this.statsLabel.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 238);
      this.statsLabel.Location = new Point(13, 13);
      this.statsLabel.Name = "statsLabel";
      this.statsLabel.Size = new Size(66, 15);
      this.statsLabel.TabIndex = 0;
      this.statsLabel.Text = "Statystyki";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(34, 33);
      this.label2.Name = "label2";
      this.label2.Size = new Size(151, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Wydruk ksiąg inwentarzowych";
      this.pictureBox1.Image = (Image) Resources.wykres;
      this.pictureBox1.Location = new Point(357, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(38, 34);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.kindLabel.Location = new Point(4, 13);
      this.kindLabel.Name = "kindLabel";
      this.kindLabel.Size = new Size(77, 13);
      this.kindLabel.TabIndex = 3;
      this.kindLabel.Text = "Rodzaj:";
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.DateCheckBox);
      this.panel1.Controls.Add((Control) this.ToDTP);
      this.panel1.Controls.Add((Control) this.endDateLabel);
      this.panel1.Controls.Add((Control) this.FromDTP);
      this.panel1.Controls.Add((Control) this.startDateLabel);
      this.panel1.Controls.Add((Control) this.SortByComboBox);
      this.panel1.Controls.Add((Control) this.sortByLabel);
      this.panel1.Controls.Add((Control) this.IdRodzajComboBox);
      this.panel1.Controls.Add((Control) this.orInInvertoryLabel);
      this.panel1.Controls.Add((Control) this.AllDbCheckBox);
      this.panel1.Controls.Add((Control) this.ValueTextBox);
      this.panel1.Controls.Add((Control) this.startWithLabel);
      this.panel1.Controls.Add((Control) this.KindComboBox);
      this.panel1.Controls.Add((Control) this.ForAllComboBox);
      this.panel1.Controls.Add((Control) this.forAllLabel);
      this.panel1.Controls.Add((Control) this.kindLabel);
      this.panel1.Location = new Point(12, 62);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(383, 269);
      this.panel1.TabIndex = 4;
      this.DateCheckBox.AutoSize = true;
      this.DateCheckBox.Location = new Point(3, 188);
      this.DateCheckBox.Name = "DateCheckBox";
      this.DateCheckBox.Size = new Size(100, 17);
      this.DateCheckBox.TabIndex = 20;
      this.DateCheckBox.Text = "Uwzględnij daty";
      this.DateCheckBox.UseVisualStyleBackColor = true;
      this.DateCheckBox.CheckedChanged += new EventHandler(this.DateCheckBox_CheckedChanged);
      this.ToDTP.Enabled = false;
      this.ToDTP.Location = new Point(88, 237);
      this.ToDTP.Name = "ToDTP";
      this.ToDTP.Size = new Size(150, 20);
      this.ToDTP.TabIndex = 17;
      this.ToDTP.ValueChanged += new EventHandler(this.ToDTP_ValueChanged);
      this.endDateLabel.Location = new Point(4, 240);
      this.endDateLabel.Name = "endDateLabel";
      this.endDateLabel.Size = new Size(77, 13);
      this.endDateLabel.TabIndex = 16;
      this.endDateLabel.Text = "Do dnia";
      this.endDateLabel.TextAlign = ContentAlignment.MiddleRight;
      this.FromDTP.Enabled = false;
      this.FromDTP.Location = new Point(88, 211);
      this.FromDTP.Name = "FromDTP";
      this.FromDTP.Size = new Size(150, 20);
      this.FromDTP.TabIndex = 15;
      this.FromDTP.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
      this.FromDTP.ValueChanged += new EventHandler(this.FromDTP_ValueChanged);
      this.startDateLabel.Location = new Point(4, 214);
      this.startDateLabel.Name = "startDateLabel";
      this.startDateLabel.Size = new Size(77, 13);
      this.startDateLabel.TabIndex = 14;
      this.startDateLabel.Text = "Od dnia";
      this.startDateLabel.TextAlign = ContentAlignment.MiddleRight;
      this.SortByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.SortByComboBox.FormattingEnabled = true;
      this.SortByComboBox.Location = new Point(88, 143);
      this.SortByComboBox.Name = "SortByComboBox";
      this.SortByComboBox.Size = new Size(150, 21);
      this.SortByComboBox.TabIndex = 13;
      this.sortByLabel.Location = new Point(1, 147);
      this.sortByLabel.Name = "sortByLabel";
      this.sortByLabel.Size = new Size(87, 13);
      this.sortByLabel.TabIndex = 12;
      this.sortByLabel.Text = "Wyniki sortuj wg:";
      this.IdRodzajComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.IdRodzajComboBox.FormattingEnabled = true;
      this.IdRodzajComboBox.Location = new Point(88, 116);
      this.IdRodzajComboBox.Name = "IdRodzajComboBox";
      this.IdRodzajComboBox.Size = new Size(251, 21);
      this.IdRodzajComboBox.TabIndex = 11;
      this.orInInvertoryLabel.Location = new Point(1, 120);
      this.orInInvertoryLabel.Name = "orInInvertoryLabel";
      this.orInInvertoryLabel.Size = new Size(86, 13);
      this.orInInvertoryLabel.TabIndex = 10;
      this.orInInvertoryLabel.Text = "lub w inwentarzu";
      this.AllDbCheckBox.AutoSize = true;
      this.AllDbCheckBox.Location = new Point(4, 98);
      this.AllDbCheckBox.Name = "AllDbCheckBox";
      this.AllDbCheckBox.Size = new Size(222, 17);
      this.AllDbCheckBox.TabIndex = 9;
      this.AllDbCheckBox.Text = "We wszystkich księgach inwentarzowych";
      this.AllDbCheckBox.UseVisualStyleBackColor = true;
      this.AllDbCheckBox.CheckedChanged += new EventHandler(this.AllDbCheckBox_CheckedChanged);
      this.ValueTextBox.Location = new Point(88, 72);
      this.ValueTextBox.Name = "ValueTextBox";
      this.ValueTextBox.Size = new Size(150, 20);
      this.ValueTextBox.TabIndex = 8;
      this.startWithLabel.AutoSize = true;
      this.startWithLabel.Location = new Point(246, 49);
      this.startWithLabel.Name = "startWithLabel";
      this.startWithLabel.Size = new Size(126, 13);
      this.startWithLabel.TabIndex = 7;
      this.startWithLabel.Text = "rozpoczynających się od:";
      this.KindComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.KindComboBox.FormattingEnabled = true;
      this.KindComboBox.Location = new Point(88, 10);
      this.KindComboBox.Name = "KindComboBox";
      this.KindComboBox.Size = new Size(150, 21);
      this.KindComboBox.TabIndex = 6;
      this.KindComboBox.SelectedIndexChanged += new EventHandler(this.KindComboBox_SelectedIndexChanged);
      this.ForAllComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ForAllComboBox.FormattingEnabled = true;
      this.ForAllComboBox.Location = new Point(88, 44);
      this.ForAllComboBox.Name = "ForAllComboBox";
      this.ForAllComboBox.Size = new Size(150, 21);
      this.ForAllComboBox.TabIndex = 5;
      this.forAllLabel.Location = new Point(4, 48);
      this.forAllLabel.Name = "forAllLabel";
      this.forAllLabel.Size = new Size(78, 13);
      this.forAllLabel.TabIndex = 4;
      this.forAllLabel.Text = "Dla wszystkich";
      this.SearchButton.Image = (Image) componentResourceManager.GetObject("SearchButton.Image");
      this.SearchButton.Location = new Point((int) sbyte.MaxValue, 340);
      this.SearchButton.Name = "SearchButton";
      this.SearchButton.Size = new Size(75, 23);
      this.SearchButton.TabIndex = 5;
      this.SearchButton.Text = "Szukaj";
      this.SearchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.SearchButton.UseVisualStyleBackColor = true;
      this.SearchButton.Click += new EventHandler(this.SearchButton_Click);
      this.ExitButton.Image = (Image) componentResourceManager.GetObject("ExitButton.Image");
      this.ExitButton.Location = new Point(208, 340);
      this.ExitButton.Name = "ExitButton";
      this.ExitButton.Size = new Size(75, 23);
      this.ExitButton.TabIndex = 6;
      this.ExitButton.Text = "Wyjście";
      this.ExitButton.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.ExitButton.UseVisualStyleBackColor = true;
      this.ExitButton.Click += new EventHandler(this.ExitButton_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(410, 374);
      this.Controls.Add((Control) this.ExitButton);
      this.Controls.Add((Control) this.SearchButton);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.statsLabel);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = nameof (WydrukKIForm);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Wydruk księgi inwentarzowej";
      this.KeyDown += new KeyEventHandler(this.WydrukKIForm_KeyDown);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public WydrukKIForm(int id_rodzaj)
    {
      this.InitializeComponent();
      Settings.SetSettings(new IniFile("coliber.ini", "coliber", false).ReadIni("SqlServer", "ConnectionString"));
      this._translationsDictionary = new Dictionary<string, string>();
      this.setControlsText();
      this.GenerateKinds();
      this.GenerateForAll();
      this.GenerateIdRodzaj(id_rodzaj);
      this.GenerateSortBy();
    }

    private void setControlsText()
    {
      this._translationsDictionary = CommonFunctions.GetAndLoadTranslations(new Dictionary<object, string>()
      {
        {
          (object) this.statsLabel,
          "stats"
        },
        {
          (object) this.label2,
          "printout_invertories"
        },
        {
          (object) this.kindLabel,
          "kind"
        },
        {
          (object) this.forAllLabel,
          "for_all"
        },
        {
          (object) this.startWithLabel,
          "start_with"
        },
        {
          (object) this.AllDbCheckBox,
          "in_all_invertories"
        },
        {
          (object) this.orInInvertoryLabel,
          "or_in_intertory"
        },
        {
          (object) this.sortByLabel,
          "sort_by"
        },
        {
          (object) this.DateCheckBox,
          "include_dates"
        },
        {
          (object) this.startDateLabel,
          "since_date"
        },
        {
          (object) this.endDateLabel,
          "to_date"
        },
        {
          (object) this.SearchButton,
          "search"
        },
        {
          (object) this.ExitButton,
          "exit"
        },
        {
          (object) this,
          "printout_invertories"
        }
      }, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void GenerateKinds()
    {
      this.KindComboBox.DataSource = (object) new BindingSource((object) new Dictionary<int, string>()
      {
        {
          1,
          this._translationsDictionary.ContainsKey("books") ? this._translationsDictionary["books"] : "Książki"
        },
        {
          2,
          this._translationsDictionary.ContainsKey("magazines") ? this._translationsDictionary["magazines"] : "Czasopisma"
        },
        {
          3,
          this._translationsDictionary.ContainsKey("serial_publications") ? this._translationsDictionary["serial_publications"] : "Wydawnictwa seryjne"
        }
      }, (string) null);
      this.KindComboBox.DisplayMember = "Value";
      this.KindComboBox.ValueMember = "Key";
    }

    private void GenerateForAll()
    {
      this.ForAllComboBox.DataSource = (object) new BindingSource((object) new Dictionary<int, string>()
      {
        {
          1,
          this._translationsDictionary.ContainsKey("signatures_genitive") ? this._translationsDictionary["signatures_genitive"] : "Sygnatur"
        },
        {
          2,
          this._translationsDictionary.ContainsKey("inventory_numbers_genitive") ? this._translationsDictionary["inventory_numbers_genitive"] : "Numerów inwentarzowych"
        }
      }, (string) null);
      this.ForAllComboBox.DisplayMember = "Value";
      this.ForAllComboBox.ValueMember = "Key";
    }

    private void GenerateIdRodzaj(int id_rodzaj)
    {
      SqlCommand Command = new SqlCommand();
      Command.CommandText = "InventoryList;";
      this.IdRodzajComboBox.DataSource = (object) new BindingSource((object) CommonFunctions.ReadData(Command, ref Settings.Connection), (string) null);
      this.IdRodzajComboBox.DisplayMember = "inwentarz";
      this.IdRodzajComboBox.ValueMember = nameof (id_rodzaj);
      this.IdRodzajComboBox.SelectedValue = (object) id_rodzaj;
      this.AllDbCheckBox.Checked = id_rodzaj == 0;
    }

    private void GenerateSortBy()
    {
      this.SortByDictionary1.Add(1, this._translationsDictionary.ContainsKey("signature_genitive") ? this._translationsDictionary["signature_genitive"] : "Sygnatury");
      this.SortByDictionary1.Add(2, this._translationsDictionary.ContainsKey("inventory_number_genitive") ? this._translationsDictionary["inventory_number_genitive"] : "Numeru inwentarzowego");
      this.SortByDictionary1.Add(3, this._translationsDictionary.ContainsKey("entry_date_genitive") ? this._translationsDictionary["entry_date_genitive"] : "Daty wpisania");
      this.SortByDictionary1.Add(4, this._translationsDictionary.ContainsKey("by_author") ? this._translationsDictionary["by_author"] : "Autora");
      this.SortByDictionary1.Add(5, this._translationsDictionary.ContainsKey("by_title") ? this._translationsDictionary["by_title"] : "Tytułu");
      this.SortByDictionary2.Add(1, this._translationsDictionary.ContainsKey("signature_genitive") ? this._translationsDictionary["signature_genitive"] : "Sygnatury");
      this.SortByDictionary2.Add(2, this._translationsDictionary.ContainsKey("inventory_number_genitive") ? this._translationsDictionary["inventory_number_genitive"] : "Numeru inwentarzowego");
      this.SortByDictionary2.Add(3, this._translationsDictionary.ContainsKey("entry_date_genitive") ? this._translationsDictionary["entry_date_genitive"] : "Daty wpisania");
      this.SortByDictionary2.Add(4, this._translationsDictionary.ContainsKey("by_title") ? this._translationsDictionary["by_title"] : "Tytułu");
      this.SortByComboBox.DataSource = (object) new BindingSource((object) this.SortByDictionary1, (string) null);
      this.SortByComboBox.DisplayMember = "Value";
      this.SortByComboBox.ValueMember = "Key";
    }

    private void AllDbCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.AllDbCheckBox.Checked)
        this.IdRodzajComboBox.Enabled = false;
      else
        this.IdRodzajComboBox.Enabled = true;
    }

    private void DateCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.FromDTP.Enabled = this.DateCheckBox.Checked;
      this.ToDTP.Enabled = this.DateCheckBox.Checked;
    }

    private void WydrukKIForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != System.Windows.Forms.Keys.Escape)
        return;
      this.Close();
    }

    private void FromDTP_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.FromDTP.Value > this.ToDTP.Value))
        return;
      int num = (int) MessageBox.Show(this._translationsDictionary.ContainsKey("start_date_cannot_be_later_than_end_date") ? this._translationsDictionary["start_date_cannot_be_later_than_end_date"] : "Data początkowa nie może być późniejsza niż data końcowa!", this._translationsDictionary.ContainsKey("invalid_date") ? this._translationsDictionary["invalid_date"] : "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.FromDTP.Focus();
    }

    private void ToDTP_ValueChanged(object sender, EventArgs e)
    {
      if (!(this.ToDTP.Value < this.FromDTP.Value))
        return;
      int num = (int) MessageBox.Show(this._translationsDictionary.ContainsKey("end_date_cannot_be_earlier_than_start_date") ? this._translationsDictionary["end_date_cannot_be_earlier_than_start_date"] : "Data końcowa nie może być wcześniejsza niż data początkowa!", this._translationsDictionary.ContainsKey("invalid_date") ? this._translationsDictionary["invalid_date"] : "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.ToDTP.Focus();
    }

    private void SearchButton_Click(object sender, EventArgs e)
    {
      if (this.DateCheckBox.Checked)
      {
        if (this.FromDTP.Value > this.ToDTP.Value)
        {
          int num = (int) MessageBox.Show(this._translationsDictionary.ContainsKey("start_date_cannot_be_later_than_end_date") ? this._translationsDictionary["start_date_cannot_be_later_than_end_date"] : "Data początkowa nie może być późniejsza niż data końcowa!", this._translationsDictionary.ContainsKey("invalid_date") ? this._translationsDictionary["invalid_date"] : "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.FromDTP.Focus();
          return;
        }
        if (this.ToDTP.Value < this.FromDTP.Value)
        {
          int num = (int) MessageBox.Show(this._translationsDictionary.ContainsKey("end_date_cannot_be_earlier_than_start_date") ? this._translationsDictionary["end_date_cannot_be_earlier_than_start_date"] : "Data końcowa nie może być wcześniejsza niż data początkowa!", this._translationsDictionary.ContainsKey("invalid_date") ? this._translationsDictionary["invalid_date"] : "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.ToDTP.Focus();
          return;
        }
      }
      try
      {
        SqlCommand Command = new SqlCommand();
        if (int.Parse(this.KindComboBox.SelectedValue.ToString()) == 1)
          Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiKsiazki @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa;";
        else if (int.Parse(this.KindComboBox.SelectedValue.ToString()) == 2)
          Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiCzasopism @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa;";
        else if (int.Parse(this.KindComboBox.SelectedValue.ToString()) == 3)
          Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiCzasopismaSeryjnego @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa;";
        if (int.Parse(this.ForAllComboBox.SelectedValue.ToString()) == 1)
        {
          Command.Parameters.AddWithValue("@syg", (object) this.ValueTextBox.Text.Trim());
          Command.Parameters.AddWithValue("@num_inw", (object) "");
        }
        else
        {
          Command.Parameters.AddWithValue("@syg", (object) "");
          Command.Parameters.AddWithValue("@num_inw", (object) this.ValueTextBox.Text.Trim());
        }
        if (this.AllDbCheckBox.Checked)
          Command.Parameters.AddWithValue("@id_rodzaj", (object) 0.ToString());
        else
          Command.Parameters.AddWithValue("@id_rodzaj", (object) this.IdRodzajComboBox.SelectedValue.ToString());
        if (this.DateCheckBox.Checked)
        {
          Command.Parameters.AddWithValue("@data_poczatkowa", (object) this.FromDTP.Value.ToShortDateString());
          Command.Parameters.AddWithValue("@data_koncowa", (object) this.ToDTP.Value.ToShortDateString());
        }
        else
        {
          Command.Parameters.AddWithValue("@data_poczatkowa", (object) DBNull.Value);
          Command.Parameters.AddWithValue("@data_koncowa", (object) DBNull.Value);
        }
        DataTable dataTable = CommonFunctions.ReadData(Command, ref Settings.Connection);
        if (dataTable.Rows.Count != 0 && dataTable.Rows[0]["ilosc"].ToString() == "0")
        {
          int num1 = (int) MessageBox.Show(this._translationsDictionary.ContainsKey("not_found") ? this._translationsDictionary["not_found"] : "Nic nie znaleziono.", this._translationsDictionary.ContainsKey("no_results") ? this._translationsDictionary["no_results"] : "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          string text = string.Format("{0} {1}\n{2}", this._translationsDictionary.ContainsKey("number_of_items_found") ? (object) this._translationsDictionary["number_of_items_found"] : (object) "Ilość znalezionych pozycji: ", (object) dataTable.Rows[0]["ilosc"].ToString(), this._translationsDictionary.ContainsKey("do_you_want_to_print") ? (object) this._translationsDictionary["do_you_want_to_print"] : (object) "Czy chcesz wydrukować?");
          string caption = this._translationsDictionary.ContainsKey("printout") ? this._translationsDictionary["printout"] : "Wydruk";
          if (dataTable.Rows.Count == 0 || MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
            return;
          ReportParameter[] Parameters = new ReportParameter[6];
          if (int.Parse(this.ForAllComboBox.SelectedValue.ToString()) == 1)
          {
            Parameters[0] = new ReportParameter("syg", this.ValueTextBox.Text.Trim());
            Parameters[1] = new ReportParameter("num_inw", "");
          }
          else
          {
            Parameters[0] = new ReportParameter("syg", "");
            Parameters[1] = new ReportParameter("num_inw", this.ValueTextBox.Text.Trim());
          }
          Parameters[2] = !this.AllDbCheckBox.Checked ? new ReportParameter("id_rodzaj", this.IdRodzajComboBox.SelectedValue.ToString()) : new ReportParameter("id_rodzaj", 0.ToString());
          Parameters[3] = new ReportParameter("sort", this.SortByComboBox.SelectedValue.ToString());
          if (this.DateCheckBox.Checked)
          {
            Parameters[4] = new ReportParameter("data_poczatkowa", this.FromDTP.Value.ToShortDateString());
            Parameters[5] = new ReportParameter("data_koncowa", this.ToDTP.Value.ToShortDateString());
          }
          else
          {
            Parameters[4] = new ReportParameter("data_poczatkowa", "1900-01-01");
            Parameters[5] = new ReportParameter("data_koncowa", DateTime.Today.ToShortDateString());
          }

		  /*
          this.Invoke((Delegate) (() =>
          {
            WF.Show((IWin32Window) this);
            WF.Update();
          }));
		  */
			
		WaitForm WF = new WaitForm();
		this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });


		MainForm mainForm = null;
          if (int.Parse(this.KindComboBox.SelectedValue.ToString()) == 1)
            mainForm = new MainForm("WydKsInw.rdl", Parameters, "coliber", Settings.ConnectionString);
          else if (int.Parse(this.KindComboBox.SelectedValue.ToString()) == 2)
            mainForm = new MainForm("WydCzaInw.rdl", Parameters, "coliber", Settings.ConnectionString);
          else if (int.Parse(this.KindComboBox.SelectedValue.ToString()) == 3)
            mainForm = new MainForm("WydSerInw.rdl", Parameters, "coliber", Settings.ConnectionString);
          WF.Close();
          if (mainForm == null)
            return;
          int num2 = (int) mainForm.ShowDialog();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void KindComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.SortByComboBox.DataSource = (object) null;
      this.SortByComboBox.DataSource = this.KindComboBox.SelectedIndex != 1 ? (object) new BindingSource((object) this.SortByDictionary1, (string) null) : (object) new BindingSource((object) this.SortByDictionary2, (string) null);
      this.SortByComboBox.DisplayMember = "Value";
      this.SortByComboBox.ValueMember = "Key";
    }
  }
}
