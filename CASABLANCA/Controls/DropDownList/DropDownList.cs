using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Propuesta_PMV.app.client.desing
{
    public class RJDropdownMenu : ContextMenuStrip
    {
        private bool isMainMenu;
        private int menuItemHeight = 25;
        private Color menuItemTextColor = Color.DimGray;
        private Color primaryColor = Color.MediumBlue;

        private Bitmap menuItemHeaderSize;

        //Constructor
        public RJDropdownMenu(IContainer container):base(container)
        {

        }

        //Propieties
        [Browsable(false)]
        public bool IsMainMenu { get => isMainMenu; set => isMainMenu = value; }
        [Browsable(false)]
        public int MenuItemHeight { get => menuItemHeight; set => menuItemHeight = value; }
        [Browsable(false)]
        public Color MenuItemTextColor { get => menuItemTextColor; set => menuItemTextColor = value; }
        [Browsable(false)]
        public Color PrimaryColor { get => primaryColor; set => primaryColor = value; }

        //Private Methods
        private void LoadMenuItemAppearence()
        {
            if(isMainMenu)
            {
                menuItemHeaderSize = new Bitmap(1, 45);
                MenuItemTextColor = Color.Black;
            }
            else
            {
                menuItemHeaderSize = new Bitmap(1, MenuItemHeight);
            }

            foreach(ToolStripMenuItem menuItemL1 in this.Items)
            {
                menuItemL1.ForeColor = menuItemTextColor;
                menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItemL1.Image == null) menuItemL1.Image = menuItemHeaderSize;

                foreach(ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems)
                {
                    menuItemL2.ForeColor = MenuItemTextColor;
                    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItemL2.Image == null) menuItemL2.Image = menuItemHeaderSize;


                    foreach (ToolStripMenuItem menuIteml3 in menuItemL2.DropDownItems)
                    {
                        menuIteml3.ForeColor = MenuItemTextColor;
                        menuIteml3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuIteml3.Image == null) menuIteml3.Image = menuItemHeaderSize;
                        //Aqui se agregaria L4 y L5 si se require
                    }
                }
            }
        }

        //Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if(this.DesignMode==false)
            {
                LoadMenuItemAppearence();
                this.Renderer = new MenuRenderer(isMainMenu, PrimaryColor, menuItemTextColor);
            }
        }
    }
}
