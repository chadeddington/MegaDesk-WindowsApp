namespace MegaDesk_Eddington
{
    partial class SearchQuotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchResultsDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchCmbo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchResultsDataGrid
            // 
            this.searchResultsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchResultsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResultsDataGrid.Location = new System.Drawing.Point(2, 58);
            this.searchResultsDataGrid.Name = "searchResultsDataGrid";
            this.searchResultsDataGrid.RowHeadersWidth = 51;
            this.searchResultsDataGrid.RowTemplate.Height = 24;
            this.searchResultsDataGrid.Size = new System.Drawing.Size(1048, 433);
            this.searchResultsDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search by material type";
            // 
            // searchCmbo
            // 
            this.searchCmbo.FormattingEnabled = true;
            this.searchCmbo.Location = new System.Drawing.Point(232, 13);
            this.searchCmbo.Name = "searchCmbo";
            this.searchCmbo.Size = new System.Drawing.Size(235, 24);
            this.searchCmbo.TabIndex = 2;
            this.searchCmbo.SelectedIndexChanged += new System.EventHandler(this.searchCmbo_SelectedIndexChanged);
            // 
            // SearchQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 503);
            this.Controls.Add(this.searchCmbo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchResultsDataGrid);
            this.Name = "SearchQuotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Quotes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchQuotes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.searchResultsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView searchResultsDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchCmbo;
    }
}