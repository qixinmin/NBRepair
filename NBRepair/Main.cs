using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaledServices;
using SaledServices.CustomsExport;

namespace NBRepair
{
    public partial class Main : Form
    {
        MakeDatabase mkdb = null;
        NBShouLiao nbsl = null;
        NBReapir nbrepair = null;
        NBTPDL nbtpdl = null;
        BOM bom = null;
        NBPack nbpack = null;
        ShipOut shipout = null;
        RatingLabel ratinglabel = null;
        StockIn stockin = null;
        StockOut stockout = null;
        LabelPrint labelprine = null;

        public Main()
        {
            InitializeComponent();
        }

        private void 机器收料检验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nbsl == null || nbsl.IsDisposed)
            {
                nbsl = new NBShouLiao();
                nbsl.MdiParent = this;
            }
           
            nbsl.WindowState = FormWindowState.Maximized;
            nbsl.BringToFront();
            nbsl.MdiParent = this;
            nbsl.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void 机器维修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nbrepair == null || nbrepair.IsDisposed)
            {
                nbrepair = new NBReapir();
                nbrepair.MdiParent = this;
            }

            nbrepair.WindowState = FormWindowState.Maximized;
            nbrepair.BringToFront();
            nbrepair.MdiParent = this;
            nbrepair.Show();

        }

        private void 机器上架测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nbtpdl == null || nbtpdl.IsDisposed)
            {
                nbtpdl = new NBTPDL ();
                nbtpdl.MdiParent = this;
            }

            nbtpdl.WindowState = FormWindowState.Maximized;
            nbtpdl.BringToFront();
            nbtpdl.MdiParent = this;
            nbtpdl.Show();

        }

        private void bOM导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bom == null || bom.IsDisposed)
            {
                bom = new BOM();
                bom.MdiParent = this;
            }

            bom.WindowState = FormWindowState.Maximized;
            bom.BringToFront();
            bom.MdiParent = this;
            bom.Show();

        }

        private void 创建数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (mkdb == null || mkdb.IsDisposed)
            {
                mkdb = new MakeDatabase ();
                mkdb.MdiParent = this;
            }

            mkdb.WindowState = FormWindowState.Maximized;
            mkdb.BringToFront();
            mkdb.MdiParent = this;
            mkdb.Show();

        }

        private void 机器出货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nbpack  == null || nbpack.IsDisposed)
            {
                nbpack = new NBPack ();
                nbpack.MdiParent = this;
            }

            nbpack.WindowState = FormWindowState.Maximized;
            nbpack.BringToFront();
            nbpack.MdiParent = this;
            nbpack.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ratinglabel == null || ratinglabel.IsDisposed)
            {
                ratinglabel = new RatingLabel ();
                ratinglabel.MdiParent = this;
            }

            ratinglabel.WindowState = FormWindowState.Maximized;
            ratinglabel.BringToFront();
            ratinglabel.MdiParent = this;
            ratinglabel.Show();

        }

        private void 机器出货ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (shipout == null || shipout.IsDisposed)
            {
                shipout = new ShipOut();
                shipout.MdiParent = this;
            }

            shipout.WindowState = FormWindowState.Maximized;
            shipout.BringToFront();
            shipout.MdiParent = this;
            shipout.Show();

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CodeSoft.POD != null)
            {
                CodeSoft.POD.Close();
            }
           // CodeSoft.CartonLabel.Close();
            if (CodeSoft.labApp != null)
            {
                CodeSoft.labApp.Quit();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (stockin == null || stockin.IsDisposed)
            {
                stockin = new StockIn ();
                stockin.MdiParent = this;
            }

            stockin.WindowState = FormWindowState.Maximized;
            stockin.BringToFront();
            stockin.MdiParent = this;
            stockin.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            if (stockout == null || stockout.IsDisposed)
            {
                stockout = new StockOut();
                stockout.MdiParent = this;
            }

            stockout.WindowState = FormWindowState.Maximized;
            stockout.BringToFront();
            stockout.MdiParent = this;
            stockout.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (labelprine == null || labelprine.IsDisposed)
            {
                labelprine = new LabelPrint ();
                labelprine.MdiParent = this;
            }

            labelprine.WindowState = FormWindowState.Maximized;
            labelprine.BringToFront();
            labelprine.MdiParent = this;
            labelprine.Show();
        }

        private ReturnCustomInfoImportForm rsimf;
        private void 上传出货海关信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {             
            if (rsimf == null || rsimf.IsDisposed)
            {
                rsimf = new ReturnCustomInfoImportForm();
                rsimf.MdiParent = this;
            }

            //rsimf.WindowState = FormWindowState.Maximized;
            rsimf.BringToFront();
            rsimf.Show();
        }

        private OpeningStockForm openingstockform;
        private void 期初库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (openingstockform == null || openingstockform.IsDisposed)
            {
                openingstockform = new OpeningStockForm();
                openingstockform.MdiParent = this;
            }

            // openingstockform.WindowState = FormWindowState.Maximized;
            openingstockform.BringToFront();
            openingstockform.Show();
        }

        private RealStockForm realstockform;
        private void 实盘库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (realstockform == null || realstockform.IsDisposed)
            {
                realstockform = new RealStockForm();
                realstockform.MdiParent = this;
            }

            // realstockform.WindowState = FormWindowState.Maximized;
            realstockform.BringToFront();
            realstockform.Show();
        }

        private StockInOutForm stockInOutform;
        private void 出入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (stockInOutform == null || stockInOutform.IsDisposed)
            {
                stockInOutform = new StockInOutForm();
                stockInOutform.MdiParent = this;
            }

            // stockInOutform.WindowState = FormWindowState.Maximized;
            stockInOutform.BringToFront();
            stockInOutform.Show();
        }

    }
}
