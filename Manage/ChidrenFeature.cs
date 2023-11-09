using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage
{
    public class ChildrenFeature
    {
        private string link;
        private string text;
        private string icon;

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public ChildrenFeature(string link, string text, string icon)
        {
            this.link = link;
            this.text = text;
            this.icon = icon;
        }
    }
}